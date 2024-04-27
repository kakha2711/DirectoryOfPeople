using DirectoryOfPeopel.Service.Interface.IRepository;

namespace DirectoryOfPeople.Repository.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly DirectoryOfPeopleDbContext _dbContext;

    private readonly Lazy<ICityRepository> _lazyCityrepository;
    private readonly Lazy<IContactInformationRepository> _lazyContactInformationRepository;
    private readonly Lazy<IPersonalityConnectionRepository> _lazyPersonalityConnectionRepository;
    private readonly Lazy<IPersonRepository> _lazyPersonRepository;

    public UnitOfWork(DirectoryOfPeopleDbContext directoryOfPeopleDbContext)
    {
        _dbContext = directoryOfPeopleDbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        _lazyCityrepository = new Lazy<ICityRepository>(() => new CityRepository(_dbContext));
        _lazyContactInformationRepository = new Lazy<IContactInformationRepository>(() => new ContactInformationRepository(_dbContext));
        _lazyPersonalityConnectionRepository = new Lazy<IPersonalityConnectionRepository>(() => new PersonalityConnectionRepository(_dbContext));
        _lazyPersonRepository = new Lazy<IPersonRepository>(() => new PersonRepository(_dbContext));
    }

    public ICityRepository cityRepository => _lazyCityrepository.Value;
    public IContactInformationRepository contactInformationRepository => _lazyContactInformationRepository.Value;
    public IPersonalityConnectionRepository personalityConnectionRepository => _lazyPersonalityConnectionRepository.Value;
    public IPersonRepository personRepository => _lazyPersonRepository.Value;


    public int SaveChange() => _dbContext.SaveChanges();

    public void BeginTransaction()
    {
        if (_dbContext.Database.CurrentTransaction != null)
            throw new InvalidOperationException("A Transaction is already in progress.");

        _dbContext.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        try
        {
            _dbContext.Database.CurrentTransaction?.Commit();
        }
        catch (Exception)
        {

            _dbContext.Database.CurrentTransaction?.Rollback();
            throw;
        }
        finally
        {
            _dbContext.Database.CurrentTransaction?.Dispose();
        }
    }

    public void RollBack()
    {
        try
        {
            _dbContext.Database.CurrentTransaction?.Rollback();
        }
        finally
        {

            _dbContext.Database.CurrentTransaction?.Dispose();
        }
    }

    public void Dispose()
    {
        _dbContext?.Dispose();
        GC.SuppressFinalize(this);
    }

}