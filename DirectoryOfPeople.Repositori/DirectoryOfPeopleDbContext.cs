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

        modelBuilder.Entity<PersonalityConnection>()
                    .HasMany(p => p.ToPerson)
                    .WithMany(p => p.ToPersonalityConnection)
                    .UsingEntity(
                                    "ToPersonalityConnectionPerson",
                                    l => l.HasOne(typeof(Person)).WithMany().HasForeignKey("ToPersonID").HasPrincipalKey(nameof(Person.ID)),
                                    k => k.HasOne(typeof(PersonalityConnection)).WithMany().HasForeignKey("ToPersonalityConnectionID").HasPrincipalKey(nameof(PersonalityConnection.ID)),
                                    m => m.HasKey("ToPersonID", "ToPersonalityConnectionID")
                                );

        modelBuilder.Entity<PersonalityConnection>()
                    .HasMany(p => p.FromPerson)
                    .WithMany(p => p.FromPersonalityConnection)
                    .UsingEntity(
                                    "FromPeopelPersonalityConnection",
                                    l => l.HasOne(typeof(Person))
                                            .WithMany()
                                            .HasForeignKey("FromPersonID")
                                            .HasPrincipalKey(nameof(Person.ID)),
                                    k => k.HasOne(typeof(PersonalityConnection))
                                            .WithMany()
                                            .HasForeignKey("FromPersonalityConnectionID")
                                            .HasPrincipalKey(nameof(PersonalityConnection.ID)),
                                    m => m.HasKey("FromPersonID", "FromPersonalityConnectionID")
                                );

        //modelBuilder.Entity<PersonalityConnection>()
        //                                .HasOne(pc => pc.FromPerson)
        //                                .WithMany(pc => pc.FromPersonalityConnection)
        //                                .HasForeignKey(pc => pc.ID)
        //                                .OnDelete(DeleteBehavior.ClientCascade);

        //modelBuilder.Entity<PersonalityConnection>()
        //                        .HasOne(pc => pc.ToPerson)
        //                        .WithMany(pc => pc.ToPersonalityConnection)
        //                        .HasForeignKey(pc => pc.ID)
        //                        .OnDelete(DeleteBehavior.ClientCascade);


        modelBuilder.Entity<PersonalityConnection>()
                                        .Property(pc => pc.ID)
                                        .HasColumnType("int")
                                        .IsRequired(true);
                                        
        modelBuilder.Entity<PersonalityConnection>()
                                        .Property(pc => pc.ConnectionType)
                                        .HasColumnType("nvarchar(35)")
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



        modelBuilder.Entity<Person>()
                            .Property(p=>p.ID)
                            .HasColumnType ("int")
                            .IsRequired(true);
        modelBuilder.Entity<Person>()
                            .Property(p=>p.FirstName)
                            .HasColumnType("nvarchar(30)")
                            .IsRequired (true);
        modelBuilder.Entity<Person>()
                            .Property(p=>p.LastName)
                            .HasColumnType("nvarchar(75)")
                            .IsRequired(true);
        modelBuilder.Entity<Person>()
                            .Property(p=>p.PersonalNumber)
                            .HasColumnType("nvarchar(11)")
                            .IsRequired(true);
        modelBuilder.Entity<Person>()
                            .Property(p => p.BirthDate)
                            .HasColumnType("date")
                            .IsRequired(true);
        modelBuilder.Entity<Person>()
                            .Property(p => p.PictureAddres)
                            .HasColumnType("nvarchar(max)")
                            .IsRequired(true);
        modelBuilder.Entity<Person>()
                            .Property(p => p.Gender)
                            .HasColumnType("nvarchar(10)")
                            .IsRequired(true);
        modelBuilder.Entity<Person>()
                            .HasOne(p => p.City)
                            .WithMany(p => p.Persons)
                            .HasForeignKey(p => p.ID);
        modelBuilder.Entity<Person>()
                            .Property(p => p.CreateDate)
                            .HasColumnType("date")
                            .HasDefaultValueSql("GetDate()")
                            .IsRequired(true);
        modelBuilder.Entity<Person>()
                            .Property(pc => pc.IsDelete)
                            .HasColumnType("bit")
                            .HasDefaultValueSql("(0)")
                            .IsRequired(true);


        modelBuilder.Entity<City>()
                            .Property(c=>c.ID)
                            .HasColumnType ("int")
                            .IsRequired (true);
        modelBuilder.Entity<City>()
                            .Property(c => c.Name)
                            .HasColumnType("nvarchar(100)")
                            .IsRequired(true);
        modelBuilder.Entity<City>()
                            .HasIndex(c => c.Name)
                            .IsUnique(true);
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
                            .Property(ci=>ci.ID)
                            .HasColumnType("int")
                            .IsRequired (true);
        modelBuilder.Entity<ContactInformation>()
                            .Property(ci => ci.ContactNamber)
                            .HasColumnType("varchar(15)")
                            .IsRequired(true);
        modelBuilder.Entity<ContactInformation>()
                            .Property(ci => ci.ContactName)
                            .HasColumnType("nvarchar(30)")
                            .IsRequired(true);
        modelBuilder.Entity<ContactInformation>()
                            .HasOne(ci=>ci.Person)
                            .WithMany(ci=>ci.ContactInformation)
                            .IsRequired(true);
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