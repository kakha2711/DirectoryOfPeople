using DirectoryOfPeopel.Service.Interface.IRepository;
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeople.Repository.Repository;

internal class PersonalityConnectionRepository : RepositoryBase<PersonalityConnection>, IPersonalityConnectionRepository
{
    private readonly DirectoryOfPeopleDbContext _dbContext;
    private readonly UnitOfWork _unitOfWork;

    internal PersonalityConnectionRepository(DirectoryOfPeopleDbContext context) : base(context)
    {
        //aq unda davwero yvela personi rom camovigo
        _dbContext = context;
        _unitOfWork = new UnitOfWork(_dbContext);
    }

    public void AddPersonalityConnection(PersonalityConnection personalityConnection)
    {
        if (personalityConnection == null)
            throw new ArgumentNullException(nameof(personalityConnection));

        Insert(personalityConnection);
    }

    public IQueryable<PersonalityConnection> GetPersonaliTyConectionFromPersonID(int FromPersonID)
    {

        IQueryable<PersonalityConnection> personalitiConection = set().Where(p => p.FromPersonID == FromPersonID);

        return personalitiConection;
    }
}