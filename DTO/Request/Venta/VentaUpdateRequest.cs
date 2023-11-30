using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.DTO.Request.Venta
{
    public class VentaUpdateRequest
    {
        public int Id { get; set; }
        public int NumVenta { get; set; }
        public ClienteModel Cliente { get; set; }
        public ProductoModel Producto { get; set; }
        public DateTime FechaVenta { get; set; }
        public string TipoPago { get; set; }
        public string TipoComprobante { get; set; }
        public int Descuento { get; set; }
        public decimal gananciaCuentasCorriente { get; set; }
        public int ProductoCantidad { get; set; }
        public int ItemCantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }
    }
}
