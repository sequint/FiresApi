namespace FiresApi.Models
{
    public class IncidentDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public bool Final { get; set; }
        public string? Updated { get; set; }
        public string? Started { get; set; }
        public string? AdminUnit { get; set; }
        public string? County { get; set; }
        public string? Location { get; set; }
        public int AcresBurned { get; set; }
        public int PercentContained { get; set; }
        public string? AgencyNames { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string? Type { get; set; }
        public string? UniqueId { get; set; }
        public string? Url { get; set; }
        public string? StartedDateOnly { get; set; }
        public bool IsActive { get; set; }
    }
}
