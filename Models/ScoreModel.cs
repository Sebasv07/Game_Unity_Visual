namespace Game_Unity.Models
{
    public class ScoreModel
    {
        public int ScoreId { get; set; }
        public int? UserId { get; set; }
        public int ? Score { get; set; }
        public DateTime? DateRegistrer { get; set; }
        public int ? Game {  get; set; }

        public bool Active { get; set; }
    }
}
