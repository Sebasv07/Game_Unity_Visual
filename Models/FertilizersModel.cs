using System.ComponentModel.DataAnnotations.Schema;

namespace Game_Unity.Models
{
    public class FertilizersModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int FertilizerId { get; set; }
        public string ? NameFertilizert {  get; set; }
        public string ? Description {  get; set; }

        public bool Active { get; set; }
    }
}
