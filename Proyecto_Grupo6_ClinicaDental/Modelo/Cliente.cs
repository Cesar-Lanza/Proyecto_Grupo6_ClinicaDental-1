using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Cliente
    {
        [Required(ErrorMessage = "La identidad es obligatorio")]
        public string? IdentidadCliente { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "La direccion es obligatorio")]
        public string? Direccion { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "El Telefono es obligatorio")]
        public string? Telefono { get; set; }

    }
}
