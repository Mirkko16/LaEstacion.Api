using LaEstacion.Persistence.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace LaEstacion.Data
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<VentaModel> Ventas { get; set; }
        public DbSet<ProveedorModel> Proveedores { get; set; }
        public DbSet<ProductoModel> Productos { get; set; }
        public DbSet<MarcaModel> Marcas { get; set; }
        public DbSet<FamiliaModel> Familias { get; set; }
        public DbSet<RubroModel> Rubros { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options) {}
        
    }
}
