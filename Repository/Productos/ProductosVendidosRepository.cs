using LaEstacion.Data;
using LaEstacion.Persistence.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace LaEstacion.Repository.Productos
{
    public class ProductosVendidosRepository : IProductoVendidoRepository
    {
        
    
        private readonly ApplicationDbContext _context;

        public ProductosVendidosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductoVendidoModel> AddProductoVendido(ProductoVendidoModel productoVendido)
        {
            try
            {
                _context.ProductosVendidos.Add(productoVendido);
                await _context.SaveChangesAsync();
                return productoVendido;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al insertar ProductoVendido", ex);
            }
        }

        public async Task<List<ProductoVendidoModel>> GetAllProductosVendidos()
        {
            try
            {
                var productosVendidos = await _context.ProductosVendidos
                    .Include(pv => pv.Producto.Marca)
                    .Include(pv => pv.Producto.Familia)
                    .Include(pv => pv.Producto.Rubro)
                    .Include(pv => pv.Producto.Unidad)
                    .Include(pv => pv.Producto.Proveedor)
                    .ToListAsync();

                return productosVendidos;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al obtener todos los productos vendidos", ex);
            }
        }

    }
}
