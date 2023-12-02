namespace LaEstacion.DTO.Request.Unidad
{
    public class UnidadUpdateRequest
    {
        public int Id { get; set; }
        public string UnidadMedida { get; set; }

        public bool Eliminada { get; set; }
    }
}
