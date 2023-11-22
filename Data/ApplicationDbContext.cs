using LaEstacion.Persistence.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace LaEstacion.Data
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<VentaModel> Ventas { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options) {}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<UsuarioModel>().HasData(
        //            new UsuarioModel { Id = 1, Nombre = "Prueba", Apellido = "Prueba1" }
        //        );
        //}
    }
}
