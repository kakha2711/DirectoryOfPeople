
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Interface.Services;

internal interface IPersonalityConnectionService
{
    Task<PersonalityConnection> GetCreatePersonalityConnection(int id);
    Task<IQueryable<PersonalityConnection>> GetPersonalityConnection();
    void CreatePersonalityConnection(PersonalityConnection personalityConnection);
    void UpdatePersonalityConnection(PersonalityConnection personalityConnection);
    void DeletePersonalityConnection(int id);
}
