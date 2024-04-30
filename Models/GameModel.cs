namespace Game_Unity.Models
{
    public class GameModel
    {
        public int GameId { get; set; }
        public required int UserId { get; set; }
        public string? DateGame { get; set; }
        public DateTime? StarDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? ScenarioId { get; set; }
        public int? Score { get; set; }
        public bool Active { get; set; }
    }
}
