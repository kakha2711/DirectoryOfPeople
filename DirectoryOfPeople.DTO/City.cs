
namespace DirectoryOfPeople.DTO;

public class City
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<Person>? Persons { get; set; }

    public DateTime CreateDate { get; set; }
    public bool IsDelete { get; set; }
}
