using LaEstacion.Data;
using LaEstacion.Persistence.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace LaEstacion.Repository.Productos
{
    public class ProductosRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductoModel> AddProducto(ProductoModel producto)
        {
            try
            {
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return producto;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al insertar producto", ex);
            }
        }


        public async Task<List<ProductoModel>> GetAllProductos()
        {
            try
            {
                var productos = await _context.Productos.ToListAsync();
                return productos;
            }
            catch (Exception ex)
            {

                throw new Exception("fallo al obtener todos los Productos", ex);
            }
        }

        public async Task<ProductoModel?> GetProductoById(int productoId)
        {
            try
            {
                var producto = await _context.Productos.FirstOrDefaultAsync(producto => producto.Id == productoId);
                return producto;
            }
            catch (Exception ex)
            {

                throw new Exception("Producto no encontrado", ex);
            }
        }

        public async Task RemoveProducto(int productoId)
        {
            try
            {
                var index = await GetProductoById(productoId);
                _context.Productos.Remove(index);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Producto", ex);
            }
        }

        public async Task<ProductoModel> UpdateProducto(ProductoModel producto, ProductoModel existingProducto)
        {
            try
            {

                existingProducto.Nombre = producto.Nombre;
                existingProducto.CodBarra = producto.CodBarra;
                existingProducto.MarcaId = producto.MarcaId;
                existingProducto.FamiliaId = producto.FamiliaId;
                existingProducto.RubroId = producto.RubroId;
                existingProducto.ProveedorId = producto.ProveedorId;
                existingProducto.Costo = producto.Costo;
                existingProducto.Rentabilidad = producto.Rentabilidad;
                existingProducto.PrecioVenta = producto.PrecioVenta;
                existingProducto.Stock = producto.Stock;
                existingProducto.Eliminado = producto.Eliminado;
                

                await _context.SaveChangesAsync();
                return existingProducto;
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo al actualizar el producto", ex);
            }
        }
    }
}
