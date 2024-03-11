
using System.ComponentModel.DataAnnotations.Schema;

namespace DirectoryOfPeople.DTO;

public class PersonalityConnection
{
    
    public int FromPersonID { get; set; }
    public Person FromPerson { get; set; } = null!;

    
    public int ToPersonID { get; set; }
    public Person ToPerson { get; set; } = null!;

    public connectionType ConnectionType { get; set; }

    public DateTime CreateDate { get; set; }
    public bool IsDelete { get; set; }
}

public enum connectionType : byte
{
    Colleague = 0,
    acquaintance = 1,
    relative = 2,
    other = 3,
}