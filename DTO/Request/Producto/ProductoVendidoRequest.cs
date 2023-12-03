using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.DTO.Request.Producto
{
    public class ProductoVendidoRequest
    {
        public int Id { get; set; }
        public ProductoModel Producto { get; set; }
        public decimal Cantidad { get; set; }
        public int ItemCantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        
    }
}
