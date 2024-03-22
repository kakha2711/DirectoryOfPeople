
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Interface.Services;

internal interface ICityService
{
    Task<City> GetCity(int id);
    Task<IQueryable<City>> GetCity();
    void CreateCity(City city);
    void UpdateCity(City city);
    void DeleteCity(int id);

}
