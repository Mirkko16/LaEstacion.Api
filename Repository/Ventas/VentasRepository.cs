using LaEstacion.Data;
using LaEstacion.DTO.Request.Venta;
using LaEstacion.Persistence.Common.Model;
using LaEstacion.Repository.Productos;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
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
                await AddProductosToVenta(venta);

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

        private async Task AddProductosToVenta(VentaModel venta)
        {
            if (venta.Productos.Any())
            {
                foreach (var producto in venta.Productos)
                {
                    producto.VentaId = venta.Id;
                    
                    var productoEnBaseDeDatos = _context.Productos.Find(producto.Producto.Id);
                    if (productoEnBaseDeDatos == null)
                    {
                        throw new Exception($"El producto con ID {producto.Id} no existe");
                    }

                    if (productoEnBaseDeDatos.Stock >= producto.Cantidad)
                    {
                        productoEnBaseDeDatos.Stock -= producto.Cantidad;
                        var productoVendido = new ProductoVendidoModel
                        {
                            Producto = productoEnBaseDeDatos,
                            Cantidad = producto.Cantidad,
                            PrecioUnitario = producto.PrecioUnitario
                        };
                        venta.Productos.Add(productoVendido);
                        await _productsVendidosRepository.AddProductoVendido(productoVendido);
                    }
                    else
                    {
                        throw new Exception($"No hay suficiente stock para el producto con ID {producto.Id}.");
                    }                 
                }
            }
        }




        public async Task<List<VentaModel>> GetAllVentas()
        {
            try
            {
                var ventas = await _context.Ventas
                    .Include(v => v.Cliente)
                    .Include(v => v.Productos)
                    .ToListAsync();
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
