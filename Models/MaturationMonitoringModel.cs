namespace Game_Unity.Models
{
    public class MaturationMonitoringModel
    {
        public int MaturationMonitoringId { get; set; }
        public int? CropId { get; set; }
        public DateTime? EstimatedRipeningDate { get; set; }
        public DateTime? EstimatedPlanningDate { get; set; }
        public string? MaturationState { get; set; }
        public string ? Observations { get; set; }

        public bool Active { get; set; }
    }
}
