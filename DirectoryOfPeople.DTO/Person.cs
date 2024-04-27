
using System.Reflection;

namespace DirectoryOfPeople.DTO;

public class Person
{
    public int ID { get; set; }
    public int? PersonIdentification { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PersonalNumber { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string? PictureAddres { get; set; }

    public Gender Gender { get; set; }
    public City? City { get; set; }

    public ICollection<ContactInformation>? ContactInformation { get; set; }
    public ICollection<PersonalityConnection>? FromPersonalityConnection { get; set; }
    public ICollection<PersonalityConnection>? ToPersonalityConnection { get; set; }

    public DateTime CreateDate { get; set; }
    public bool IsDelete { get; set; }
}

public enum Gender : byte
{
    Male = 0,
    Feamel = 1,
}