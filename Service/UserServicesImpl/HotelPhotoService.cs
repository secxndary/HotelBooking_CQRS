using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.BadRequest.Collections;
using Entities.Exceptions.NotFound;
using Entities.Models.UserModels;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Service.UserServicesImpl;

public sealed class HotelPhotoService : IHotelPhotoService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public HotelPhotoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public async Task<(IEnumerable<HotelPhotoDto> hotelPhotos, MetaData metaData)> GetHotelPhotosAsync
        (Guid hotelId, HotelPhotoParameters hotelPhotoParameters)
    {
        await CheckIfHotelExists(hotelId);

        var hotelPhotosWithMetaData = await _repository.HotelPhoto.GetHotelPhotosAsync(hotelId, hotelPhotoParameters, trackChanges: false);
        var hotelPhotosDto = _mapper.Map<IEnumerable<HotelPhotoDto>>(hotelPhotosWithMetaData);
        
        return (hotelPhotos: hotelPhotosDto, metaData: hotelPhotosWithMetaData.MetaData);
    }

    public async Task<IEnumerable<HotelPhotoDto>> GetByIdsAsync(Guid hotelId, IEnumerable<Guid> ids)
    {
        if (ids is null)
            throw new IdParametersBadRequestException();

        await CheckIfHotelExists(hotelId);

        var hotelPhotos = await _repository.HotelPhoto.GetByIdsAsync(hotelId, ids, trackChanges: false);
        if (hotelPhotos.Count() != ids.Count())
            throw new CollectionByIdsBadRequestException();

        var hotelPhotosDto = _mapper.Map<IEnumerable<HotelPhotoDto>>(hotelPhotos);
        return hotelPhotosDto;
    }

    public async Task<HotelPhotoDto> GetHotelPhotoAsync(Guid hotelId, Guid id)
    {
        await CheckIfHotelExists(hotelId);

        var hotelPhoto = await GetHotelPhotoAndCheckIfItExists(hotelId, id, trackChanges: false);
        var hotelPhotoDto = _mapper.Map<HotelPhotoDto>(hotelPhoto);

        return hotelPhotoDto;
    }

    public async Task<HotelPhotoDto> CreateHotelPhotoAsync(Guid hotelId, HotelPhotoForCreationDto hotelPhoto)
    {
        await CheckIfHotelExists(hotelId);

        var hotelPhotoEntity = _mapper.Map<HotelPhoto>(hotelPhoto);
        _repository.HotelPhoto.CreateHotelPhoto(hotelId, hotelPhotoEntity);
        await _repository.SaveAsync();

        var hotelPhotoToReturn = _mapper.Map<HotelPhotoDto>(hotelPhotoEntity);
        return hotelPhotoToReturn;
    }

    public async Task<(IEnumerable<HotelPhotoDto> hotelPhotos, string ids)> CreateHotelPhotoCollectionAsync
        (Guid hotelId, IEnumerable<HotelPhotoForCreationDto> hotelPhotosCollection)
    {
        if (hotelPhotosCollection is null)
            throw new HotelPhotoCollectionBadRequest();

        var hotelPhotosEntities = _mapper.Map<IEnumerable<HotelPhoto>>(hotelPhotosCollection);
        foreach (var hotelPhoto in hotelPhotosEntities)
            _repository.HotelPhoto.CreateHotelPhoto(hotelId, hotelPhoto);
        await _repository.SaveAsync();

        var hotelPhotosCollectionToReturn = _mapper.Map<IEnumerable<HotelPhotoDto>>(hotelPhotosEntities);
        var ids = string.Join(",", hotelPhotosCollectionToReturn.Select(p => p.Id));
        return (hotelPhotos: hotelPhotosCollectionToReturn, ids);
    }

    public async Task<HotelPhotoDto> UpdateHotelPhotoAsync(Guid hotelId, Guid id, HotelPhotoForUpdateDto hotelPhotoForUpdate)
    {
        await CheckIfHotelExists(hotelId);

        var hotelPhotoEntity = await GetHotelPhotoAndCheckIfItExists(hotelId, id, trackChanges: true);
        _mapper.Map(hotelPhotoForUpdate, hotelPhotoEntity);
        await _repository.SaveAsync();
        
        var hotelPhotoToReturn = _mapper.Map<HotelPhotoDto>(hotelPhotoEntity);
        return hotelPhotoToReturn;
    }

    public async Task<(HotelPhotoForUpdateDto hotelPhotoToPatch, HotelPhoto hotelPhotoEntity)> 
        GetHotelPhotoForPatchAsync(Guid hotelId, Guid id)
    {
        await CheckIfHotelExists(hotelId);

        var hotelPhotoEntity = await GetHotelPhotoAndCheckIfItExists(hotelId, id, trackChanges: true);
        var photoToPatch = _mapper.Map<HotelPhotoForUpdateDto>(hotelPhotoEntity);

        return (photoToPatch, hotelPhotoEntity);
    }

    public async Task<HotelPhotoDto> SaveChangesForPatchAsync(HotelPhotoForUpdateDto hotelPhotoToPatch, HotelPhoto hotelPhotoEntity)
    {
        _mapper.Map(hotelPhotoToPatch, hotelPhotoEntity);
        await _repository.SaveAsync();

        var hotelPhotoToReturn = _mapper.Map<HotelPhotoDto>(hotelPhotoEntity);
        return hotelPhotoToReturn;
    }

    public async Task DeleteHotelPhotoAsync(Guid hotelId, Guid id)
    {
        await CheckIfHotelExists(hotelId);

        var hotelPhoto = await GetHotelPhotoAndCheckIfItExists(hotelId, id, trackChanges: false);

        _repository.HotelPhoto.DeleteHotelPhoto(hotelPhoto);
        await _repository.SaveAsync();
    }


    private async Task CheckIfHotelExists(Guid hotelId)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges: false);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);
    }

    private async Task<HotelPhoto> GetHotelPhotoAndCheckIfItExists(Guid hotelId, Guid id, bool trackChanges)
    {
        var hotelPhoto = await _repository.HotelPhoto.GetHotelPhotoAsync(hotelId, id, trackChanges);
        if (hotelPhoto is null)
            throw new HotelPhotoNotFoundException(id);
        return hotelPhoto;
    }
}