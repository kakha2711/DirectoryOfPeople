using DirectoryOfPeopel.Service.Interface.IRepository;
using DirectoryOfPeopel.Service.Interface.IServices;
using DirectoryOfPeopel.Service.Services;
using DirectoryOfPeople.Maping;
using DirectoryOfPeople.Repository;
using DirectoryOfPeople.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace DirectoryOfPeople.Configuration;

public static class DependencyConfiguration
{
    public static void ConfigureDependency(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));

        string connectionString =
            builder.Configuration.GetConnectionString("DefaultConnection") ??
            throw new ArgumentException(nameof(builder));

        builder.Services.AddDbContext<DirectoryOfPeopleDbContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddAutoMapper(typeof(Mapping));

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<ICityService, CityService>();
        builder.Services.AddScoped<IContactInformationService, ContactInformationService>();
        builder.Services.AddScoped<IPersonalityConnectionService, PersonalityConnectionServiceService>();
        builder.Services.AddScoped<IPersonService, PersonService>();
    }
}
