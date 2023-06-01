using FullStack.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Data
{
    public class GuestAPIDbcontext : DbContext
    {
        public GuestAPIDbcontext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Guest> Guests{ get; set; }
    }
}
