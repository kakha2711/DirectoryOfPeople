
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Interface.IRepository;

public interface IPersonalityConnectionRepository : IRepositoryBase<PersonalityConnection>
{
    void AddPersonalityConnection(PersonalityConnection personalityConnection);
    IQueryable<PersonalityConnection> GetPersonaliTyConectionFromPersonID(int FromPersonID);
}
