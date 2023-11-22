using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaEstacion.Persistence.Common.Model
{
    public class VentaModel : BaseModel
    {
        public int NumVenta { get; set; }
        public ClienteModel Cliente {get;set;}      
        public DateTime FechaVenta { get; set; }
        public string TipoPago { get; set; }
        public int Descuento { get; set; }
        public decimal gananciaCuentasCorriente { get; set; }
        public decimal Total { get; set; }
    }
}
