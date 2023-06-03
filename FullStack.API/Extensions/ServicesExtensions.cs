using Microsoft.EntityFrameworkCore;
using Repositories.Core;

namespace FullStack.API.Extensions
{
    public  static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<RepositoryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
