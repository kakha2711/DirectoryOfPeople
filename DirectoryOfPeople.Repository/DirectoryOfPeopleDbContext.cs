using DirectoryOfPeople.DTO;
using Microsoft.EntityFrameworkCore;

namespace DirectoryOfPeople.Repository;

public class DirectoryOfPeopleDbContext :DbContext
{
    public DirectoryOfPeopleDbContext(DbContextOptions<DirectoryOfPeopleDbContext> dbOptions) : base(dbOptions)
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
                            .Property(p => p.ID)
                            .HasColumnType("int")
                            .IsRequired(true);
        modelBuilder.Entity<Person>()
                            .Property(p => p.PersonIdentification)
                            .HasColumnType("int")
                            .IsRequired(false);
        modelBuilder.Entity<Person>()
                            .Property(p => p.FirstName)
                            .HasColumnType("nvarchar(30)")
                            .IsRequired(true);
        modelBuilder.Entity<Person>()
                            .Property(p => p.LastName)
                            .HasColumnType("nvarchar(75)")
                            .IsRequired(true);
        modelBuilder.Entity<Person>()
                            .Property(p => p.PersonalNumber)
                            .HasColumnType("nvarchar(11)")
                            .IsRequired(true);
        modelBuilder.Entity<Person>()
                            .Property(p => p.BirthDate)
                            .HasColumnType("date")
                            .IsRequired(true);
        modelBuilder.Entity<Person>()
                            .Property(p => p.PictureAddres)
                            .HasColumnType("nvarchar(max)")
                            .IsRequired(false);
        modelBuilder.Entity<Person>()
                            .Property(p => p.Gender)
                            .HasColumnType("tinyint")
                            .IsRequired(true);
        modelBuilder.Entity<Person>()
                            .Property(p => p.CreateDate)
                            .HasColumnType("date")
                            .HasDefaultValueSql("GetDate()");
        modelBuilder.Entity<Person>()
                            .Property(pc => pc.IsDelete)
                            .HasColumnType("bit")
                            .HasDefaultValueSql("(0)")
                            .IsRequired(true);
        modelBuilder.Entity<Person>()
                            .HasMany(p => p.ToPersonalityConnection)
                            .WithOne(p => p.ToPerson)
                            .HasForeignKey(p => p.ToPersonID)
                            .HasPrincipalKey(p => p.ID)
                            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Person>()
                            .HasMany(p => p.FromPersonalityConnection)
                            .WithOne(p => p.FromPerson)
                            .HasForeignKey(p => p.FromPersonID)
                            .HasPrincipalKey(p => p.ID)
                            .OnDelete(DeleteBehavior.NoAction);



        modelBuilder.Entity<PersonalityConnection>()
                                        .HasKey(p => new { p.ToPersonID, p.FromPersonID })
                                        .HasName("ToPersonID");
        modelBuilder.Entity<PersonalityConnection>()
                                        .Property(pc => pc.ConnectionType)
                                        .HasColumnType("tinyint")
                                        .IsRequired(true);
        modelBuilder.Entity<PersonalityConnection>()
                                        .Property(pc => pc.CreateDate)
                                        .HasColumnType("date")
                                        .HasDefaultValueSql("GetDate()")
                                        .IsRequired(true);
        modelBuilder.Entity<PersonalityConnection>()
                                        .Property(pc => pc.IsDelete)
                                        .HasColumnType("bit")
                                        .HasDefaultValueSql("(0)")
                                        .IsRequired(true);



        modelBuilder.Entity<City>()
                            .Property(c => c.ID)
                            .HasColumnType("int")
                            .IsRequired(true);
        modelBuilder.Entity<City>()
                            .Property(c => c.Name)
                            .HasColumnType("nvarchar(100)")
                            .IsRequired(true);
        modelBuilder.Entity<City>()
                            .HasIndex(c => c.Name)
                            .IsUnique(true);
        modelBuilder.Entity<City>()
                            .HasMany(p => p.Persons)
                            .WithOne(p => p.City)
                            .IsRequired(false);
        modelBuilder.Entity<City>()
                            .Property(p => p.CreateDate)
                            .HasColumnType("date")
                            .HasDefaultValueSql("GetDate()")
                            .IsRequired(true);
        modelBuilder.Entity<City>()
                            .Property(pc => pc.IsDelete)
                            .HasColumnType("bit")
                            .HasDefaultValueSql("(0)")
                            .IsRequired(true);

        modelBuilder.Entity<ContactInformation>()
                            .Property(ci => ci.ID)
                            .HasColumnType("int")
                            .IsRequired(true);
        modelBuilder.Entity<ContactInformation>()
                            .Property(ci => ci.ContactNamber)
                            .HasColumnType("varchar(15)")
                            .IsRequired(true);
        modelBuilder.Entity<ContactInformation>()
                            .Property(ci => ci.ContactName)
                            .HasColumnType("tinyint")
                            .IsRequired(true);
        modelBuilder.Entity<ContactInformation>()
                            .HasOne(ci => ci.Person)
                            .WithMany(ci => ci.ContactInformation)
                            .IsRequired(false);
        modelBuilder.Entity<ContactInformation>()
                            .Property(p => p.CreateDate)
                            .HasColumnType("date")
                            .HasDefaultValueSql("GetDate()")
                            .IsRequired(true);
        modelBuilder.Entity<ContactInformation>()
                            .Property(pc => pc.IsDelete)
                            .HasColumnType("bit")
                            .HasDefaultValueSql("(0)")
                            .IsRequired(true);

    }
}
