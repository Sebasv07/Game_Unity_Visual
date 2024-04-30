using System.ComponentModel.DataAnnotations.Schema;

namespace Game_Unity.Models
{
    public class CropPestsModel
    {
        [ForeignKey("CropPests")]
        public int ? Crop { get; set; }
        public int ? Plague { get; set; }
        public bool Active { get; set; }

    }
}
