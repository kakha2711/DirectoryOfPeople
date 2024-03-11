
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Interface.Services;

internal interface IContactInformationService
{
    ContactInformation GetContactInformation(int id);
    ContactInformation GetContactInformation();
    void CreateContactInformation(ContactInformation contactInformation);
    void UpdateContactInformation(ContactInformation contactInformation);
    void DeleteContactInformation(int id);

}
