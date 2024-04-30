using Microsoft.Identity.Client;

namespace Game_Unity.Models
{
    public class DetectiveCluesModel
    {
        public int DetectiveCluesId { get; set; }
        public required int DetectiveId { get; set; }
        public string ? Description { get; set; }
        public string? Type { get; set; }
        public DateTime ? CollectionDate { get; set; }
        public bool ? SolutionMistery {  get; set; }

        public bool Active { get; set; }

    }
}
