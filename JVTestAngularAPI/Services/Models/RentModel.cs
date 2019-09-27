using System;
using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class RentModel : RentModelBase
    {
        public DateTime RentedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }
        public decimal HourlyRate { get; set; }
    }

    public class RentModelBase : BaseModel
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public long SkiId { get; set; }
    }
}
