
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Interface.Services;

internal interface PersonalityConnectionService
{
    PersonalityConnection GetCreatePersonalityConnection(int id);
    PersonalityConnection GetPersonalityConnection();
    void CreatePersonalityConnection(PersonalityConnection personalityConnection);
    void UpdatePersonalityConnection(PersonalityConnection personalityConnection);
    void DeletePersonalityConnection(int id);
}
