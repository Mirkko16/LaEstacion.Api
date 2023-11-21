using LaEstacion.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaEstacion.Modulos.Venta
{
    public class VentaModel :BaseModel
    {
        [Column(TypeName = "int")]
        public int NumVenta { get; set; }
    }
}
