using DirectoryOfPeopel.Service.Interface.IRepository;
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeople.Repository.Repository;

internal class CityRepository : RepositoryBase<City>, ICityRepository
{
    internal CityRepository(DirectoryOfPeopleDbContext context) : base(context)
    {

    }

    public City GetCityById(int id)
    {
        City city = Get(id);

        return city;
    }

    public City GetCityByPerson(Person person)
    {
        City city = set(p => p.Persons == person).FirstOrDefault() ?? throw new ArgumentNullException("Not found");

        return city;
    }
}
