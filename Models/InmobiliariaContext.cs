using Microsoft.EntityFrameworkCore;

namespace Inmobiliaria.Models
{
    public class InmobiliariaContext : DbContext
    {
        public InmobiliariaContext(DbContextOptions<InmobiliariaContext> options) : base(options) { }

        public DbSet<Propiedad> Propiedades { get; set; }
    }
}
