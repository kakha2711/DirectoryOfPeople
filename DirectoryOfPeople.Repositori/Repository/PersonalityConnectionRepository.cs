using DirectoryOfPeopel.Service.Interface.Repository;
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeople.Repositori.Repository;

internal class PersonalityConnectionRepository : RepositoryBase<PersonalityConnection>, IPersonalityConnectionRepository
{
    internal PersonalityConnectionRepository(DirectoryOfPeopleDbContext context) : base(context)
    {

    }
}
