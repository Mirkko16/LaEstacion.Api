using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.DTO.Request.Producto
{
    public class ProductoVendidoUpdateRequest
    {
        public int Id { get; set; }
        public ProductoModel Producto { get; set; }
        public decimal Cantidad { get; set; }        
        public decimal PrecioUnitario { get; set; }
        
    }
}
