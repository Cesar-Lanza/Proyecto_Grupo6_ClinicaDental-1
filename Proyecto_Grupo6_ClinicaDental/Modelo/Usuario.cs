using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Usuario
    {
        [Required(ErrorMessage = "El codigo es obligatorio")]
        public string? CodigoUsuario { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "La clave es obligatoria")]
        public string? Clave { get; set; }
        public string? Correo { get; set; }
        [Required(ErrorMessage = "El Rol es obligatorio")]
        public string? Rol { get; set; }
        public bool EstaActivo { get; set; }

        public Usuario()
        {
        }

        public Usuario(string? codigoUsuario, string? nombre, string? clave, string? correo, string? rol, bool estaActivo)
        {
            CodigoUsuario = codigoUsuario;
            Nombre = nombre;
            Clave = clave;
            Correo = correo;
            Rol = rol;
            EstaActivo = estaActivo;
        }
    }
}



