using LaEstacion.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaEstacion.Modulos.Usuarios
{
    public class UsuarioModel :BaseModel
    {
        [Column(TypeName = "varchar(150)")]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Apellido { get; set; }

    }
}
