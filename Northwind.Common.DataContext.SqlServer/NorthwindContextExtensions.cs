using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Packt.Shared;

public static class NorthwindContextExtensions
{
    public static IServiceCollection AddNorthwindContext(
        this IServiceCollection services,
        string connectionString = "Data Source=.;Initial Catalog=Northwind;User Id=sa; Password=W9*s74tk44UwCY6naX8pGa7qX; TrustServerCertificate=True;MultipleActiveResultsets=true;"
    )
    {
        services.AddDbContext<NorthwindContext>(options =>
            options.UseSqlServer(connectionString)
        );

        return services;
    }
}