using System.ComponentModel.DataAnnotations;

namespace LaEstacion.Persistence.Common
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

    }

}
