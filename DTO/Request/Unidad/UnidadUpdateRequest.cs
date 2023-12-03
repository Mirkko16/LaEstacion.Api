namespace LaEstacion.DTO.Request.Unidad
{
    public class UnidadUpdateRequest
    {
        public int Id { get; set; }
        public string Unidad { get; set; }

        public bool Eliminada { get; set; }
    }
}
