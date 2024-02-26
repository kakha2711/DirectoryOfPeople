using DirectoryOfPeople.Repositori;
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
    }
}
