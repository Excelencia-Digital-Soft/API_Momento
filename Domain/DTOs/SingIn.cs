
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class SingIn
    {
        [Required]
        public  string User { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
