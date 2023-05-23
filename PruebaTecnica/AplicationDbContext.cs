using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Entidades;

namespace PruebaTecnica
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)  { }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Direcciones> Direcciones { get; set; }


    }
}
