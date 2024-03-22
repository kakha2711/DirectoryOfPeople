
using DirectoryOfPeopel.Service.Interface.Repository;
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeople.Repositori.Repository;

internal class PersonRepository : RepositoryBase<Person>, IPersonRepository
{
    internal PersonRepository(DirectoryOfPeopleDbContext Context): base(Context)
    {

    }
}
