using DirectoryOfPeople.DTO;
using Microsoft.EntityFrameworkCore;

namespace DirectoryOfPeople.Repositori;

public class DirectoryOfPeopleDbContext : DbContext
{
    public DirectoryOfPeopleDbContext(DbContextOptions<DirectoryOfPeopleDbContext> options) : base(options)
    { 
    
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<ContactInformation> ContactInformation { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<PersonalityConnection> PersonalityConnections { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<PersonalityConnection>()
        //            .HasOne(p => p.Person)
        //            .WithMany(p => p.WhichPerson)
        //            .HasForeignKey<Person>(p=>p.PersonID);
    }
}