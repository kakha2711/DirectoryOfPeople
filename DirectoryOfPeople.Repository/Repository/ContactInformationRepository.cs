
using DirectoryOfPeopel.Service.Interface.IRepository;
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeople.Repository.Repository;

internal class ContactInformationRepository : RepositoryBase<ContactInformation>, IContactInformationRepository
{
    private readonly DirectoryOfPeopleDbContext _context;
    private readonly UnitOfWork _unitOfWork;

    internal ContactInformationRepository(DirectoryOfPeopleDbContext context) : base(context)
    {
        _context = context;
        _unitOfWork = new UnitOfWork(context);
    }

    public void AddContactInformation(ContactInformation contactInformation)
    {
        if (contactInformation == null) throw new ArgumentNullException(nameof(contactInformation));

        Insert(contactInformation);
    }

    public IQueryable<ContactInformation> GetContactByPerson(Person person)
    {
        IQueryable<ContactInformation> contactInformation = set(p => p.Person == person);
        return contactInformation;
    }

    public ContactInformation GetContactById(int id)
    {
        var contactInformation = Get(id);


        return contactInformation;
    }
}