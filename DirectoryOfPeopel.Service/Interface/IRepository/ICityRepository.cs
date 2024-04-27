
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Interface.IRepository;

public interface ICityRepository : IRepositoryBase<City>
{
    public City GetCityById(int id);

    public City GetCityByPerson(Person person);
}