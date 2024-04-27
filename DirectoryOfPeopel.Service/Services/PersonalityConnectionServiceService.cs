
using DirectoryOfPeopel.Service.Interface.IRepository;
using DirectoryOfPeopel.Service.Interface.IServices;
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Services;

public class PersonalityConnectionServiceService : IPersonalityConnectionService
{
    private readonly IUnitOfWork _unitOfWork;

    public PersonalityConnectionServiceService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<PersonalityConnection> GetCreatePersonalityConnection(int id)
    {  
        PersonalityConnection personalityConnection = _unitOfWork.personalityConnectionRepository.Get(id);
        return Task.FromResult(personalityConnection);
    }

    public Task<IQueryable<PersonalityConnection>> GetPersonalityConnection()
    {
        IQueryable<PersonalityConnection> personalityConnections = _unitOfWork.personalityConnectionRepository.set();

        if (personalityConnections == null) throw new ArgumentNullException("The Account could not be found");

        return Task.FromResult(personalityConnections);
    }

    public void CreatePersonalityConnection(PersonalityConnection personalityConnection)
    {
        if (personalityConnection == null) throw new ArgumentNullException(nameof(personalityConnection));

        _unitOfWork.personalityConnectionRepository.Insert(personalityConnection);
        _unitOfWork.SaveChange();

    }

    public void UpdatePersonalityConnection(PersonalityConnection personalityConnection)
    {
        if (personalityConnection == null) throw new ArgumentNullException(nameof(personalityConnection));

        _unitOfWork.personalityConnectionRepository.Update(personalityConnection);
        _unitOfWork.SaveChange();
    }

    public void DeletePersonalityConnection(int id)
    {
        PersonalityConnection personalityConnection = _unitOfWork.personalityConnectionRepository.Get(id);

        personalityConnection.IsDelete = false;

        _unitOfWork.personalityConnectionRepository.Update(personalityConnection);
        _unitOfWork.SaveChange();
    }
}