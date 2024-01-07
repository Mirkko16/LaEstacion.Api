namespace LaEstacion.DTO.Request.User
{
    public class UserRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UserLogIn { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }
    }
}
