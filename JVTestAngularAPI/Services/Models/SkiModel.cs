namespace Services.Models
{
    public class SkiModel : BaseModel
    {
        public string Name { get; set; }

        public decimal HourlyRate { get; set; }

        public bool Rented { get; set; }
    }
}
