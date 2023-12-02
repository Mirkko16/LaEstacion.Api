namespace LaEstacion.Persistence.Common.Model
{
    public class ProductoVendidoModel :BaseModel
    {
        public ProductoModel Producto { get; set; }

        public decimal Cantidad { get; set; }

        public UnidadModel Unidad { get; set; }
    }
}
