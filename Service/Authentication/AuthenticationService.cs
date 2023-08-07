using AutoMapper;
using Contracts;
using Service.Contracts.Authentication;
using Microsoft.AspNetCore.Identity;
using Entities.Models;
using Shared.DataTransferObjects.AuthenticationDtos;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Entities.Exceptions.BadRequest.Authentication;
using Entities.ConfigurationModels;
using Microsoft.Extensions.Options;
namespace Service.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    private readonly UserManager<UserIdentity> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    private readonly IOptionsSnapshot<JwtConfiguration> _configuration;
    private readonly JwtConfiguration _jwtConfiguration;
    
    private UserIdentity? _user;

    public AuthenticationService(ILoggerManager logger, IMapper mapper, UserManager<UserIdentity> userManager, 
        RoleManager<IdentityRole> roleManager, IOptionsSnapshot<JwtConfiguration> configuration)
    {
        _logger = logger;
        _mapper = mapper;
        _configuration = configuration;
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _jwtConfiguration = _configuration.Value;
    }


    public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
    {
        var user = _mapper.Map<UserIdentity>(userForRegistration);
        var result = await _userManager.CreateAsync(user, userForRegistration.Password!);

        foreach (var role in userForRegistration.Roles!)
            if (!await _roleManager.RoleExistsAsync(role))
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "RoleNotExist",
                    Description = $"Role {role} does not exist."
                });
            }

        if (result.Succeeded)
            await _userManager.AddToRolesAsync(user, userForRegistration.Roles!);

        return result;
    }

    public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication)
    {
        _user = await _userManager.FindByNameAsync(userForAuthentication.UserName!);
        var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuthentication.Password!));

        if (!result)
            _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Incorrect username or password.");

        return result;
    }

    public async Task<TokenDto> CreateToken(bool populateExpiration)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        var refreshToken = GenerateRefreshToken();
        _user!.RefreshToken = refreshToken;

        if (populateExpiration)
            _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(Convert.ToDouble(_jwtConfiguration.RefreshExpiresDays));

        await _userManager.UpdateAsync(_user);
        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return new TokenDto(accessToken, refreshToken);
    }

    public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
    {
        var principal = GetPrincipalForExpiredToken(tokenDto.AccessToken);
        
        var user = await _userManager.FindByNameAsync(principal.Identity!.Name!);
        if (user == null || user.RefreshToken != tokenDto.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            throw new RefreshTokenBadRequest();

        _user = user;
        return await CreateToken(populateExpiration: false);
    }


    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET")!);
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, _user!.UserName!)
        };

        var roles = await _userManager.GetRolesAsync(_user);
        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken
        (
            issuer: _jwtConfiguration.ValidIssuer,
            audience: _jwtConfiguration.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.AccessExpiresMinutes)),
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private ClaimsPrincipal GetPrincipalForExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = _jwtConfiguration.ValidateLifetime,
            ValidateIssuerSigningKey = true,

            ValidIssuer = _jwtConfiguration.ValidIssuer,
            ValidAudience = _jwtConfiguration.ValidAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET")!))
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals
            (SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }
}