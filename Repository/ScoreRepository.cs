using Game_Unity.Context;
using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Repository
{
    public interface IScoreRepository
    {
        Task<List<ScoreModel>> GetAll();
        Task<ScoreModel> GetScore(int idScore);
        Task<ScoreModel> CreateScore
            (int UserId, int Score, DateTime DateRegistrer, int Game, bool Active);

        Task<ScoreModel> UpdateScore(ScoreModel score);
        Task<ScoreModel> DeleteScore(ScoreModel score);

    }

    public class ScoreRepository: IScoreRepository
    {
        private readonly ScoreContext _db;
        public ScoreRepository(ScoreContext db)
        {
            _db = db;
        }

        public async Task<List<ScoreModel>> GetAll()
        {
            return await _db.Scores.ToListAsync();
        }

        public async Task<ScoreModel> GetScore(int idScore)
        {
            return await _db.Scores.FirstOrDefaultAsync(u => u.ScoreId == idScore);
        }


        public async Task<ScoreModel> CreateScore(int UserId, int Score, DateTime DateRegistrer, int Game, bool Active)
        {
            ScoreModel newScore = new ScoreModel
            {
                UserId = UserId,
                Score = Score,
                DateRegistrer = DateRegistrer,
                Game = Game,
                Active = Active
            };

            await _db.Scores.AddAsync(newScore);
            _db.SaveChangesAsync();
            return newScore;
        }

        public async Task<ScoreModel> DeleteScore(ScoreModel score)
        {
            _db.Scores.Update(score);
            await _db.SaveChangesAsync();
            return score;
        }
        public async Task<ScoreModel> UpdateScore(ScoreModel score)
        {
            _db.Scores.Update(score);
            await _db.SaveChangesAsync();
            return score;
        }
    }
}
