namespace LaEstacion.DTO.Request.Familia
{
    public class FamiliaUpdateRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Eliminada { get; set; }
    }
}
