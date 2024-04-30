using System.ComponentModel.DataAnnotations.Schema;

namespace Game_Unity.Models
{
    public class BatchModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BachnetId { get; set; }
        public string ? Location { get; set; }

        public int ? Size { get; set; }
        public string ? SoilType { get; set; }

        public string ? Descripcion { get; set; }
        public bool Active { get; set; }

    }
}
