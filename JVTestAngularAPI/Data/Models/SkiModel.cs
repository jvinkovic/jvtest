using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class SkiModel : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal HourlyRate { get; set; }

        public bool Rented { get; set; }
    }
}
