
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Interface.Services;

internal interface ICityService
{
    City GetCity(int id);
    IQueryable<City> GetCity();
    void CreateCity(City city);
    void UpdateCity(City city);
    void DeleteCity(int id);

}
