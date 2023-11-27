namespace LaEstacion.DTO.Request.Proveedor
{
    public class ProveedorUpdateRequest
    {
        public int Id { get; set; }
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
