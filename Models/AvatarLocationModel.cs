namespace Game_Unity.Models
{
    public class AvatarLocationModel
    {
        public int AvatarLocationId { get; set; }
        public int GameId { get; set; }
        public int DetectiveId { get; set; }
        public decimal ? CoordinatesX {  get; set; }
        public decimal? CoordinatesY { get; set; }
        public decimal? CoordinatesZ { get; set; }
        public bool Active { get; set; }
    }
}
