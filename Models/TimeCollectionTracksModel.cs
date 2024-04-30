namespace Game_Unity.Models
{
    public class TimeCollectionTracksModel
    {
        public int TimeCollectionTracksId { get; set; }
        public required int DetectiveId { get; set; }
        public required int GameId {  get; set; }
        public required int DetectiveCluesId { get; set; }
        public DateTime ? TimeClues {  get; set; }
        public bool Active { get; set; }



    }
}
