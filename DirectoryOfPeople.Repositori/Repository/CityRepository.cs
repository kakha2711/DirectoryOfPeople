using DirectoryOfPeopel.Service.Interface.Repository;
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeople.Repositori.Repository;

internal class CityRepository:RepositoryBase<City>, ICityRepository
{
    internal CityRepository(DirectoryOfPeopleDbContext context):base(context)
    {

    }
}
