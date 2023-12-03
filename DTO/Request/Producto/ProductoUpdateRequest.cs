using LaEstacion.Persistence.Common.Model;

namespace LaEstacion.DTO.Request.Producto
{
    public class ProductoUpdateRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodBarra { get; set; }
        public MarcaModel Marca { get; set; }
        public FamiliaModel Familia { get; set; }
        public RubroModel Rubro { get; set; }
        public UnidadModel Unidad { get; set; }
        public ProveedorModel Proveedor { get; set; }
        public decimal Costo { get; set; }
        public decimal Rentabilidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Stock { get; set; }
        public bool Eliminado { get; set; }
    }
}
