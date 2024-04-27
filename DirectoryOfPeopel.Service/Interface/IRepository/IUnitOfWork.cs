
namespace DirectoryOfPeopel.Service.Interface.IRepository;

public interface IUnitOfWork : IDisposable
{
    public ICityRepository cityRepository { get; }
    public IContactInformationRepository contactInformationRepository { get; }
    public IPersonalityConnectionRepository personalityConnectionRepository { get; }
    public IPersonRepository personRepository { get; }
    int SaveChange();
    void BeginTransaction();
    void CommitTransaction();
    void RollBack();
}
