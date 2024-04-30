using System.ComponentModel.DataAnnotations.Schema;

namespace Game_Unity.Models
{
    public class PlagueModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlagueId { get; set; }
        public string? NamePlague { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }

    }
}

