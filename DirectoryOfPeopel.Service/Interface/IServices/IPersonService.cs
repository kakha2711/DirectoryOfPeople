using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Interface.IServices;

public interface IPersonService
{
    Task<Person> GetPerson(int id);
    Task<IQueryable<Person>> GetPerson();
    void CreatePerson(Person person);
    void UpdatePerson(Person person);
    void DeletePerson(int id);
}
