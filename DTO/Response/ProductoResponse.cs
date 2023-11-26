namespace LaEstacion.DTO.Response
{
    public class ProductoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodBarra { get; set; }
        public int Marca { get; set; }
        public int Familia { get; set; }
        public int Rubro { get; set; }
        public int Proveedor { get; set; }
        public decimal Costo { get; set; }
        public decimal Rentabilidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Stock { get; set; }
        public bool Eliminado { get; set; }
    }
}
