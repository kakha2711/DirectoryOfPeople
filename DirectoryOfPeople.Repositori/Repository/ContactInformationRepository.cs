using DirectoryOfPeopel.Service.Interface.Repository;
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeople.Repositori.Repository;

internal class ContactInformationRepository:RepositoryBase<ContactInformation>, IContactInformationRepository
{
    internal ContactInformationRepository(DirectoryOfPeopleDbContext context):base(context)
    {

    }
}
