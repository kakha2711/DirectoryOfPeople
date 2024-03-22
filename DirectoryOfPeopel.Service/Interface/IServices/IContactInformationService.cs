
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Interface.Services;

internal interface IContactInformationService
{
    Task<ContactInformation> GetContactInformation(int id);
    Task<IQueryable<ContactInformation>> GetContactInformation();
    void CreateContactInformation(ContactInformation contactInformation);
    void UpdateContactInformation(ContactInformation contactInformation);
    void DeleteContactInformation(int id);

}
