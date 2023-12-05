using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.DTO.Request.Producto
{
    public class ProductoVendidoRequest
    {
        public int Id { get; set; }
        public int Producto { get; set; }
        public decimal Cantidad { get; set; }        
        public decimal PrecioUnitario { get; set; }
        
    }
}
