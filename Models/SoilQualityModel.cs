using System.ComponentModel.DataAnnotations.Schema;

namespace Game_Unity.Models
{
    public class SoilQualityModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int SoilQualityId { get; set; }
        public string? TypeSoilQuality { get; set; }
        public string? NutrientLevel { get; set; }
        public decimal? PH { get; set; }
        public string ? Description { get; set; }
        public bool Active { get; set; }
    }
}
