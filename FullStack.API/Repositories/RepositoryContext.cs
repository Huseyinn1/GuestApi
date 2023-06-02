
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Guest> Guests{ get; set; }
    }
}
