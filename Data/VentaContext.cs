using Microsoft.EntityFrameworkCore;
using Examen_DEWES_JuanJose_acebedo_lara2.Models.Entity;

namespace Examen_DEWES_JuanJose_acebedo_lara.Data
{
    public class VentaContext : DbContext
    {
        public VentaContext(DbContextOptions<VentaContext> options)
            : base(options)
        {
        }

        public DbSet<Venta> Productos { get; set; }
    }
}
