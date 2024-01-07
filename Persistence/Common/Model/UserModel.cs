using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaEstacion.Persistence.Common.Model
{
    public class UserModel :BaseModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }        
        public string Username { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
    }
}
