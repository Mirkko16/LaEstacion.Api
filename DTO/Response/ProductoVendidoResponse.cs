using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.DTO.Response
{
    public class ProductoVendidoResponse
    {
        public int Id { get; set; }
        public ProductoModel Producto { get; set; }
        public decimal Cantidad { get; set; }        
        public decimal PrecioUnitario { get; set; }
     
    }
}
