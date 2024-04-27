using DirectoryOfPeopel.Service.Interface.IRepository;
using DirectoryOfPeopel.Service.Interface.IServices;
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Services;

public class CityService : ICityService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICityRepository _cityRepository;

    public CityService(IUnitOfWork unitOfWork, ICityRepository cityRepository)
    {
        _unitOfWork = unitOfWork;
        _cityRepository = cityRepository;
    }

    public Task<City> GetCity(int id)
    { 
        /*_unitOfWork.cityRepository.Get(id)*/
        City city = _cityRepository.Get(id);
            return Task.FromResult(city);
    }

    public Task<IQueryable<City>> GetCity()
    {
        //IQueryable<City> city = _unitOfWork.cityRepository.set();

        IQueryable<City> city = _cityRepository.set();

        if (city == null)
            throw new ArgumentNullException("The City could not be found");

        return Task.FromResult(city);
    }

    public void CreateCity(City city)
    {
        if (city == null) throw new ArgumentNullException(nameof(city));

        _cityRepository.Insert(city);
        //_unitOfWork.cityRepository.Insert(city);
        _unitOfWork.SaveChange();
    }

    public void UpdateCity(City city)
    {
        if (city == null) throw new ArgumentNullException(nameof(city));

        _cityRepository.Update(city);
        //_unitOfWork.cityRepository.Update(city);
        _unitOfWork.SaveChange();
    }

    public void DeleteCity(int id)
    {
        if (id <= 0) throw new ArgumentNullException(nameof(id));
        City city = _unitOfWork.cityRepository.Get(id);

        city.IsDelete = false;

        _cityRepository.Update(city);
        //_unitOfWork.cityRepository.Update(city);
        _unitOfWork.SaveChange();
    }

}
