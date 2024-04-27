
namespace DirectoryOfPeople.DTO;

public class ContactInformation
{
    public int ID { get; set; }
    public string ContactNamber { get; set; } = null!;
    public ContactName ContactName { get; set; }
    public Person? Person { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDelete { get; set; }
}

public enum ContactName : byte
{
    Mobail = 0,
    Ofice = 1,
    Home = 2,
    Email = 3,
}