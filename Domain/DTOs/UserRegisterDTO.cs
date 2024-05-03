

using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Pass { get; set; } = null!;

        [Required]
        public string NameFull { get; set; } = null!;

        [Required(ErrorMessage = "El campo Cuil es requerido")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El campo Cuil debe tener exactamente 11 caracteres")]

        public string Cuil { get; set; } = null!;

        [Required(ErrorMessage = "El campo Mail es requerido")]
        [EmailAddress(ErrorMessage = "El campo Mail debe ser una dirección de correo electrónico válida")]
        public string Mail { get; set; } = null!;

        public DateTime BirthDate { get; set; }
    }
}
