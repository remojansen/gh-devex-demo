namespace github_platform_demo_domain.Models
{
    public class WeatherAlert
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? AlertType { get; set; }
        public string? Description { get; set; }
        public string? Severity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}