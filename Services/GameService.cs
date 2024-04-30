using Game_Unity.Models;
using Game_Unity.Repository;
using System;

namespace Game_Unity.Services
{
    public interface IGameService
    {
        Task<List<GameModel>> GetAll();
        Task<GameModel> GetGame(int IdGame);
        Task<GameModel> CreateGame
            (int UserId, string DateGame, DateTime StarDate, DateTime EndDate, TimeSpan Duration, int ScenarioId, int Score, bool Active);
        Task<GameModel> UpdateGame
            (int GameId, int ? UserId, string ? DateGame, DateTime ? StarDate, DateTime ? EndDate, TimeSpan ? Duration, int? ScenarioId, int ? Score, bool active);
        Task<GameModel> DeleteGame(int IdGame, bool Active);

    }
    public class GameService: IGameService
    {
        public readonly IGameRepository _igameRepository;
        public GameService(IGameRepository igameRepository)
        {
            _igameRepository = igameRepository;
        }

        public async Task<List<GameModel>> GetAll()
        {
            return await _igameRepository.GetAll();
        }

        public async Task<GameModel> GetGame(int IdGame)
        {
            return await _igameRepository.GetGame(IdGame);
        }


        public async Task<GameModel> CreateGame(int UserId, string DateGame, DateTime StarDate, DateTime EndDate, TimeSpan Duration, int ScenarioId, int Score, bool active)
        {
            return await _igameRepository.CreateGame(UserId,DateGame, StarDate, EndDate, Duration, ScenarioId, Score, true);
        }

        public async Task<GameModel> DeleteGame(int IdGame, bool Active)
        {
            GameModel GameToDelete = await _igameRepository.GetGame(IdGame);

            if (GameToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                GameToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _igameRepository.UpdateGame(GameToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("Game not found.");
            }
        }
        public async Task<GameModel> UpdateGame(int GameId, int? UserId, string? DateGame, DateTime? StarDate, DateTime? EndDate, TimeSpan? Duration, int? ScenarioId, int? Score, bool active)
        {
            GameModel newGame= await _igameRepository.GetGame(GameId);

            if (newGame != null)
            {
                if (newGame!= null)
                {
                   // newGame.GameId = GameId;
                    newGame.UserId = (int)UserId;
                    newGame.DateGame = DateGame;
                    newGame.StarDate = StarDate;
                    newGame.EndDate = EndDate;
                    newGame.Duration = Duration;
                    newGame.ScenarioId = ScenarioId;
                    newGame.Score = Score;
                    newGame.Active = active;
                }
                return await _igameRepository.UpdateGame(newGame);
            }
            throw new NotImplementedException();
        }
    }
}
