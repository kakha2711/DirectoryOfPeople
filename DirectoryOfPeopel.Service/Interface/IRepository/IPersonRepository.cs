using DirectoryOfPeople.DTO;
using Microsoft.AspNetCore.Http;

namespace DirectoryOfPeopel.Service.Interface.IRepository;

public interface IPersonRepository : IRepositoryBase<Person>
{
    void AddPerson(Person person);
    Person GetPersonById(int id);
    IEnumerable<Person> GetPeopleRelatedToThePerson(int id);
    void UploadPersonPicture(int id, IFormFile fromFile);
    void UpdatePersonPicture(int id, IFormFile fromFile);
}