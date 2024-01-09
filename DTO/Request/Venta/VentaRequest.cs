using LaEstacion.DTO.Request.Producto;
using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.DTO.Request.Venta
{
    public class VentaRequest
    {

        public int NumVenta { get; set; }
        public int PuntoVenta { get; set; }
        public int ClienteId  { get; set; }
        public List<ProductoVendidoRequest> Productos { get; set; }
        public DateTime FechaVenta { get; set; }
        public string TipoPago { get; set; }
        public string TipoComprobante { get; set; }
        public int Descuento { get; set; }
        public decimal GananciaCuentasCorriente { get; set; }              
        public decimal Total { get; set; }
    }
}
