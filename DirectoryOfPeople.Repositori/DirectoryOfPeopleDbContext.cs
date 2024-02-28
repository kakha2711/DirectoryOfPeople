using DirectoryOfPeople.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

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

        modelBuilder.Entity<Person>()
                    .HasMany(p => p.PersonalityConnections)
                    .WithOne(p => p.Person)
                    .HasForeignKey(p => p.PersonID);

        modelBuilder.Entity<Person>()
            .HasMany(p => p.WithWhomPerson)
                    .WithOne(p => p.WithWhomPerson)
                    .HasForeignKey(p => p.WithWhomPersonID)
                    .OnDelete(DeleteBehavior.ClientCascade);
    }
}