using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.Repository.Productos
{
    public interface IProductoVendidoRepository
    {
        Task<List<ProductoVendidoModel>> GetAllProductosVendidos();

        Task<ProductoVendidoModel> AddProductoVendido(ProductoVendidoModel productoVendido);

    }
}
