using System.ComponentModel.DataAnnotations;

namespace EndToEnd.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Imie")]
        public string FromName { get; set; }
        [Required, Display(Name = "Twój email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required]
        public string Message { get; set; }
    }
}