namespace LaEstacion.DTO.Request
{
    public class ClienteUpdateRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string CUIT { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public bool Activo { get; set; }
        public bool CuentaCorriente { get; set; }
        public bool TarjetaSocio { get; set; }
        public int PuntosTarjeta { get; set; }
        public string NumeroTarjeta { get; set; }
    }
}
