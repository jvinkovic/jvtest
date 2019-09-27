using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class RentModel : BaseModel
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public DateTime RentedAt { get; set; }

        public DateTime? ReturnedAt { get; set; }

        [Required]
        public decimal HourlyRate { get; set; }

        [Required]
        public long SkiId { get; set; }

        [ForeignKey(nameof(SkiId))]
        public virtual SkiModel Ski { get; set; }
    }
}
