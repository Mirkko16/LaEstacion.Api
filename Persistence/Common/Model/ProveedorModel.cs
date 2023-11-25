using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaEstacion.Persistence.Common.Model
{
    public class ProveedorModel : BaseModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }        
        public string CUIT { get; set; }
        public string Correo { get; set; }        
        public string Telefono { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public decimal Saldo { get; set; }
        public bool Activo { get; set; }        

    }
}
