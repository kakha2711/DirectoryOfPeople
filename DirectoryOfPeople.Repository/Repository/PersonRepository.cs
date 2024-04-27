
using DirectoryOfPeopel.Service.Interface.IRepository;
using DirectoryOfPeopel.Validation;
using DirectoryOfPeople.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;

namespace DirectoryOfPeople.Repository.Repository;

internal class PersonRepository : RepositoryBase<Person>, IPersonRepository
{
    int PersonIdentification = 0;
    private readonly DirectoryOfPeopleDbContext _context;
    private readonly UnitOfWork _unitOfWork;
    //private readonly IPersonRepository _personRepository;


    public PersonRepository(DirectoryOfPeopleDbContext Context) : base(Context)
    {
        _context = Context;

        _unitOfWork = new UnitOfWork(_context);

    }

    public void AddPerson(Person person)
    {
        if (person == null) throw new ArgumentNullException(nameof(person));

        EnglishOrGeorgian englishOrGeorgian = new EnglishOrGeorgian();

        var valueFirstName = englishOrGeorgian.IsValid(person.FirstName);
        var valueLastName = englishOrGeorgian.IsValid(person.LastName);

        string fullName = person.FirstName + person.LastName;
        var valueFulName =englishOrGeorgian.IsValid(fullName);

        
        if (!valueFirstName || !valueLastName || !valueFulName)
        {
            var errorMesage = englishOrGeorgian.FormatErrorMessage(person.FirstName);
            
            throw new InvalidDataException(errorMesage);
        }
        person.PersonIdentification = GeneReitPersonIdentity();

            Insert(person);

    }


    public int GeneReitPersonIdentity()
    {
        PersonIdentification++;
        return PersonIdentification;
    }

    public void UploadPersonPicture(int id, IFormFile fromFile)
    {
        Person person = Get(id);

        person.PictureAddres = PictureUploadOrUpdate(id, fromFile);

        Update(person);

    }

    public string PictureUploadOrUpdate(int id, IFormFile fromFile)
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "DirectoryOfPeople\\Picture");

        if (!Directory.Exists(filePath))
            Directory.CreateDirectory(filePath);

        FileInfo fileInfo = new FileInfo(fromFile.FileName);

        var fileName = id.ToString() + fileInfo.Extension;

        string fileNameWithPath = Path.Combine(filePath, fileName);

        using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            fromFile.CopyTo(stream);

        return fileNameWithPath;

    }

    public void UpdatePersonPicture(int id, IFormFile fromFile)
    {
        PictureUploadOrUpdate(id, fromFile);
    }

    public Person GetPersonById(int id)
    {
        return Get(id);
    }

    public IEnumerable<Person> GetPeopleRelatedToThePerson(int id)
    {

        IQueryable<PersonalityConnection> personalityConnection = _unitOfWork
                                                                    .personalityConnectionRepository
                                                                    .GetPersonaliTyConectionFromPersonID(id);

        IQueryable<Person> person = from r in personalityConnection
                                    join p in set()
                                    on r.ToPersonID equals p.ID
                                    select p;

        return person;
    }
}
