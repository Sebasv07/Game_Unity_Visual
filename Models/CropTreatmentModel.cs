using System.ComponentModel.DataAnnotations.Schema;

namespace Game_Unity.Models
{
    public class CropTreatmentModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CropTreatmentId { get; set; }
        public int? CropId { get; set; }
        public int ? FertilizerId { get; set; }
        public string? TypeTreatment { get; set; }
        public DateTime? DateTreatment { get; set; }
        public string? ProductUsed { get; set; }
        public decimal? QuantityUsed { get; set; }
        public string? ApplicationMethod { get; set; }
        public string? Observations { get; set; }
        public bool Active { get; set; }

    }
}
