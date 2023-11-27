namespace LaEstacion.DTO.Request.Marca
{
    public class MarcaUpdateRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Eliminada { get; set; }
    }
}
