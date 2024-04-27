
using DirectoryOfPeopel.Service.Interface.IRepository;
using DirectoryOfPeopel.Service.Interface.IServices;
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Services;

public class PersonService : IPersonService
{
    private readonly IUnitOfWork _unitOfWork;

    public PersonService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<Person> GetPerson(int id)
    {
        Person person = _unitOfWork.personRepository.Get(id);

        if (person == null) throw new ArgumentNullException(nameof(person));

        return Task.FromResult(person);
    }

    public Task<IQueryable<Person>> GetPerson()
    {
        IQueryable<Person> people = _unitOfWork.personRepository.set();

        if (people == null) throw new ArgumentNullException(nameof(people));

        return Task.FromResult(people);
    }

    public void CreatePerson(Person person)
    {
        if (person == null) throw new ArgumentNullException(nameof(person));

        _unitOfWork.personRepository.Insert(person);
        _unitOfWork.SaveChange();
    }

    public void UpdatePerson(Person person)
    {
        if (person == null) throw new ArgumentNullException(nameof(person));

        _unitOfWork.personRepository.Update(person);
        _unitOfWork.SaveChange();
    }

    public void DeletePerson(int id)
    {
        Person person = _unitOfWork.personRepository.Get(id);

        person.IsDelete = false;

        _unitOfWork.personRepository.Update(person);
        _unitOfWork.SaveChange();
    }
}