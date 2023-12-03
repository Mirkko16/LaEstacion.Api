using LaEstacion.Data;
using LaEstacion.DTO.Request.Venta;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Productos;
using Microsoft.EntityFrameworkCore;

namespace LaEstacion.Repository.Ventas
{
    public class VentasRepository : IVentaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductoVendidoRepository _productsVendidosRepository;

        public VentasRepository(ApplicationDbContext context, IProductoVendidoRepository productsVendidosRepository)
        {
            _context = context;
            _productsVendidosRepository = productsVendidosRepository;
        }

        public async Task<VentaModel> AddVenta(VentaModel venta)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                if (venta.Productos.Any())
                {
                    foreach (var producto in venta.Productos)
                    {
                        producto.VentaId = venta.Id;
                        producto.Producto = _context.Productos.Find(producto.Producto.Id);

                        // Crear un objeto ProductoVendidoModel antes de asignarlo
                        var productoVendido = new ProductoVendidoModel
                        {
                            Producto = producto.Producto,
                            Cantidad = producto.Cantidad,
                            ItemCantidad = producto.ItemCantidad,
                            PrecioUnitario = producto.PrecioUnitario
                        };

                        // Asignar el objeto ProductoVendidoModel a la propiedad correspondiente
                        venta.Productos.Add(productoVendido);

                        await _productsVendidosRepository.AddProductoVendido(productoVendido);
                    }
                }

                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();

                transaction.Commit();

                return venta;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Fallo al insertar venta", ex);
            }
        }



        public async Task<List<VentaModel>> GetAllVentas()
        {
            try
            {
                var ventas = await _context.Ventas.ToListAsync();
                return ventas;
            }
            catch (Exception ex)
            {

                throw new Exception("fallo al obtener todas las ventas", ex);
            }
        }

        public async Task<VentaModel?> GetVentaById(int ventaId)
        {
            try
            {
                var venta = await _context.Ventas.FirstOrDefaultAsync(venta => venta.Id == ventaId);
                return venta;
            }
            catch (Exception ex)
            {

                throw new Exception("Venta no encontrada", ex);
            }
        }

    }
}
