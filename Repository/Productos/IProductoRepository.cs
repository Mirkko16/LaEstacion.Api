using LaEstacion.DTO.Request.Producto;
using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.Repository.Productos
{
    public interface IProductoRepository
    {
        Task<List<ProductoModel>> GetAllProductos();
        Task<ProductoModel?> GetProductoById(int productoId);
        Task<ProductoModel?> getProductobyBarCode(string codigoBarra);
        Task<ProductoModel> AddProducto(ProductoRequest producto);
        Task<ProductoModel> UpdateProducto(ProductoUpdateRequest producto, ProductoModel existingProducto);
        Task RemoveProducto(int producto);
    }
}
