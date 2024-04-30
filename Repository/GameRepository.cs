using Game_Unity.Context;
using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Repository
{
    public interface IGameRepository
    {
        Task<List<GameModel>> GetAll();
        Task<GameModel> GetGame(int idGame);
        Task<GameModel> CreateGame
        (int UserId, string DateGame, DateTime StarDate, DateTime EndDate, TimeSpan Duration, int ScenarioId, int Score, bool Active);
        Task<GameModel> UpdateGame(GameModel game);
        Task<GameModel> DeleteGame(GameModel game);
    }

    public class GameRepository: IGameRepository
    {
        private readonly GameContext _db;
        public GameRepository(GameContext db)
        {
            _db = db;
        }

        public async Task<List<GameModel>> GetAll()
        {
            return await _db.Games.ToListAsync();
        }

        public async Task<GameModel> GetGame(int idGame)
        {
            return await _db.Games.FirstOrDefaultAsync(u => u.GameId == idGame);
        }
        public async Task<GameModel> CreateGame(int UserId, string DateGame, DateTime StarDate, DateTime EndDate, TimeSpan Duration, int ScenarioId, int Score, bool Active)
        {
            GameModel newGame = new GameModel
            {
               UserId = UserId,
               DateGame = DateGame,
               StarDate = StarDate,
               EndDate = EndDate,
               Duration = Duration,
               ScenarioId = ScenarioId,
               Score = Score,
               Active = Active
            };

            await _db.Games.AddAsync(newGame);
            _db.SaveChangesAsync();
            return newGame;
        }

        public async Task<GameModel> DeleteGame(GameModel game)
        {
            _db.Games.Update(game);
            await _db.SaveChangesAsync();
            return game;
        }
        public async Task<GameModel> UpdateGame(GameModel game)
        {
            _db.Games.Update(game);
            await _db.SaveChangesAsync();
            return game;
        }
    }
}
