
namespace Domain.DTOs.Exeptions
{
    public class ExceptionDTO
    {
        public int IdUser { get; set; }

        public string Controller { get; set; } = null!;

        public string Action { get; set; } = null!;

        public string ExceptionMsg { get; set; } = null!;

    }
}
