using Tiendita.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Tiendita.API.Data
{
    public class ApplicationDbContext : IdentityDbContext   
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<User> registroCuentas { get; set; }
       public DbSet<Botana> Botanas { get; set; }
    }
}
