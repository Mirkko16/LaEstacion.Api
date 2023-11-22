namespace LaEstacion.DTO.Response
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public char Activo { get; set; }
        public char CuentaCorriente { get; set; }
        public char TarjetaSocio { get; set; }
        public int PuntosTarjeta { get; set; }
        public string NumeroTarjeta { get; set; }
    }
}
