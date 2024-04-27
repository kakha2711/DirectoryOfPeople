using DirectoryOfPeopel.Service.Interface.IRepository;
using DirectoryOfPeopel.Service.Interface.IServices;
using DirectoryOfPeople.DTO;

namespace DirectoryOfPeopel.Service.Services;

public class ContactInformationService : IContactInformationService
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactInformationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<ContactInformation> GetContactInformation(int id)
    {  
        ContactInformation contactInformation = _unitOfWork.contactInformationRepository.Get(id);
        return Task.FromResult(contactInformation);
    }

    public Task<IQueryable<ContactInformation>> GetContactInformation()
    {
        IQueryable<ContactInformation> contactInformation = _unitOfWork.contactInformationRepository.set();

        return Task.FromResult(contactInformation);
    }

    public void CreateContactInformation(ContactInformation contactInformation)
    {
        if (contactInformation == null) throw new ArgumentNullException(nameof(contactInformation));

        _unitOfWork.contactInformationRepository.Insert(contactInformation);
        _unitOfWork.SaveChange();
    }

    public void UpdateContactInformation(ContactInformation contactInformation)
    {
        if (contactInformation == null) throw new ArgumentNullException(nameof(contactInformation));

        _unitOfWork.contactInformationRepository.Update(contactInformation);
        _unitOfWork.SaveChange();
    }

    public void DeleteContactInformation(int id)
    {
        ContactInformation contactInformation = _unitOfWork.contactInformationRepository.Get(id);

        contactInformation.IsDelete = false;

        _unitOfWork.contactInformationRepository.Update(contactInformation);
        _unitOfWork.SaveChange();
    }
}
