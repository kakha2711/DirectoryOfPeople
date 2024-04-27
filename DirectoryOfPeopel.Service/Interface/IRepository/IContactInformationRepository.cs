
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Interface.IRepository;

public interface IContactInformationRepository : IRepositoryBase<ContactInformation>
{
    void AddContactInformation(ContactInformation contactInformation);
    IQueryable<ContactInformation> GetContactByPerson(Person person);

    ContactInformation GetContactById(int id);
}
