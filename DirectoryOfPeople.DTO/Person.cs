namespace DirectoryOfPeople.DTO;

public class Person
{
    public int ID { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PersonalNumber { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string PictureAddres { get; set; } = null!;

    public Gender Gender { get; set; }
    public City City { get; set; } = null!;

    public ICollection<ContactInformation> ContactInformation { get; set; } = null!;
    public ICollection<PersonalityConnection> PersonalityConnections  { get; set; } = null!;
    public ICollection<PersonalityConnection> WithWhomPerson { get; set; } = null!;

    public DateTime CreateDate { get; set; }
    public bool IsDelete { get; set; }
}

public enum Gender : byte
{
    Woman = 0,
    man = 1,
}