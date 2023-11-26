using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.Repository.Productos
{
    public interface IProductoRepository
    {
        Task<List<ProductoModel>> GetAllProductos();
        Task<ProductoModel?> GetProductoById(int productoId);
        Task<ProductoModel> AddProducto(ProductoModel producto);
        Task<ProductoModel> UpdateProducto(ProductoModel producto, ProductoModel existingProducto);
        Task RemoveProducto(int producto);
    }
}
