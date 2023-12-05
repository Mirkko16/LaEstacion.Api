namespace LaEstacion.Persistence.Common.Model
{
    public class ProductoVendidoModel :BaseModel
    {
        public ProductoModel Producto { get; set; }
        public decimal Cantidad { get; set; }        
        public decimal PrecioUnitario { get; set; }
        public int VentaId { get; set; }
        
    }
}
