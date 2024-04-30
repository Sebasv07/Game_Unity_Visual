using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;

namespace Game_Unity.Services
{
    public interface IScoreService
    {
        Task<List<ScoreModel>> GetAll();
        Task<ScoreModel> GetScore(int IdScore);
        Task<ScoreModel> CreateScore
            (int UserId, int Score, DateTime DateRegistrer, int Game, bool Active);
        Task<ScoreModel> UpdateScore
            (int ScoreId, int ? UserId, int ? Score, DateTime ? DateRegistrer, int? Game,bool Active);
        Task<ScoreModel> DeleteScore(int IdScore, bool Active);

    }


    public class ScoreService: IScoreService
    {
        public readonly IScoreRepository _iscorerepository;

        public ScoreService(IScoreRepository iscoreRepository)
        {
            _iscorerepository = iscoreRepository;
        }

        public async Task<List<ScoreModel>> GetAll()
        {
            return await _iscorerepository.GetAll();
        }

        public async Task<ScoreModel> GetScore(int IdScore)
        {
            return await _iscorerepository.GetScore(IdScore);
        }


        public async Task<ScoreModel> CreateScore(int UserId, int Score, DateTime DateRegistrer, int Game, bool Active)
        {
            return await _iscorerepository.CreateScore(UserId, Score, DateRegistrer, Game, Active);
        }

        public async Task<ScoreModel> DeleteScore(int IdScore, bool Active)
        {
            ScoreModel ScoreToDelete = await _iscorerepository.GetScore(IdScore);

            if (ScoreToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                ScoreToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _iscorerepository.UpdateScore(ScoreToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("Score not found.");
            }
        }
        public async Task<ScoreModel> UpdateScore(int ScoreId, int? UserId, int? Score, DateTime? DateRegistrer, int? Game, bool Active)
        {
            ScoreModel newScore = await _iscorerepository.GetScore(ScoreId);
            if (newScore != null)
            {
                if (newScore != null)
                {
                 //   newScore.ScoreId = ScoreId;
                    newScore.UserId = UserId;
                    newScore.Score = Score;
                    newScore.DateRegistrer = DateRegistrer;
                    newScore.Game = Game;
                    newScore.Active = Active;
                }
                return await _iscorerepository.UpdateScore(newScore);
            }
            throw new NotImplementedException();
        }
    }
}
