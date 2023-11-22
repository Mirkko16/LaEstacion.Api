﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaEstacion.Persistence.Common.Model
{
    public class UsuarioModel :BaseModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }        
        public string UserLogIn { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
        public char Activo { get; set; }
    }
}
