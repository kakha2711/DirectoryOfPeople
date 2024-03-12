
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Interface.Services;

internal interface PersonService
{
    Person GetPerson(int id);
    Person GetPerson();
    void CreatePerson(Person person);
    void UpdatePerson(Person person);
    void DeletePerson(int id);
}
