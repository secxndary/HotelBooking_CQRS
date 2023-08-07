using Microsoft.AspNetCore.Http;
using Shared.RequestFeatures.UserParameters;
namespace Entities.LinkModels;

public record LinkParameters
(
    RoomParameters RoomParameters,
    HttpContext Context
);