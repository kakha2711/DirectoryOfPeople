using DirectoryOfPeopel.Service.Interface.Repository;
using DirectoryOfPeopel.Service.Interface.Services;
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Services
{
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<City> GetCity(int id)
        {
            try
            {
                City city = _unitOfWork.cityRepository.Get(id);
                return Task.FromResult(city);
            }
            catch (KeyNotFoundException ex)
            {
                throw new InvalidDataException("The City object could not be found", ex);
            }
        }

        public Task<IQueryable<City>> GetCity()
        {
            var city = _unitOfWork.cityRepository.set();

            if (city == null)
                throw new ArgumentNullException("The City could not be found");

            return Task.FromResult(city);
        }

        public void CreateCity(City city)
        {
            if(city == null) throw new ArgumentNullException(nameof(city));

            _unitOfWork.cityRepository.Insert(city);
            _unitOfWork.SaveChange();
        }

        public void UpdateCity(City city)
        {
            if (city == null) throw new ArgumentNullException(nameof(city));

            _unitOfWork.cityRepository.Update(city);
            _unitOfWork.SaveChange();
        }

        public void DeleteCity(int id)
        {
            if (id <= 0) throw new ArgumentNullException(nameof(id));
            City city =_unitOfWork.cityRepository.Get(id);

            city.IsDelete = false;

            _unitOfWork.cityRepository.Update(city);
            _unitOfWork.SaveChange();
        }
        
    }
}
