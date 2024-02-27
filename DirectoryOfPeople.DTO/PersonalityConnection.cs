
using System.ComponentModel.DataAnnotations.Schema;

namespace DirectoryOfPeople.DTO;

public class PersonalityConnection
{
    public int ID { get; set; }

    //[ForeignKey("Person")]
    public int PersonID { get; set; }
    public Person Person { get; set; } = null!;

    //[ForeignKey("Person")]
    public int WithWhomPersonID { get; set; }
    public Person WithWhomPerson { get; set; } = null!;

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