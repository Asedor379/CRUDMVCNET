using System.ComponentModel.DataAnnotations;

namespace CRUDMVCNET.Models
{
    public class ContactoModel
    {
        public int IdContacto { get; set; }
        [Required (ErrorMessage ="campo obligatorio")]
        public string? Nombre { get; set; }
        [Required (ErrorMessage = "campo obligatorio")]
        public string? Telefono { get; set; }
        [Required (ErrorMessage = "campo obligatorio")]
        public string? Correo { get; set; }
    }
}
