using Game_Unity.Context;
using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Game_Unity.Repository
{
    public interface IScenaryRepository
    {
        Task<List<SceneryModel>> GetAll();
        Task<SceneryModel> GetScenery(int idScenery);
        Task<SceneryModel> CreateScenery
            (string NameScenery, string DescriptionScenery, int DifficultyLevel, string Location, DateTime CreationDate, bool Active);

        Task<SceneryModel> UpdateScenery(SceneryModel scenery);
        Task<SceneryModel> DeleteScenery(SceneryModel scenery);
    }

    public class SceneryRepository: IScenaryRepository
    {
        private readonly SceneryContext _db;
        public SceneryRepository(SceneryContext db)
        {
            _db = db;
        }

        public async Task<List<SceneryModel>> GetAll()
        {
            return await _db.Sceneries.ToListAsync();
        }

        public async Task<SceneryModel> GetScenery(int idScenery)
        {
            return await _db.Sceneries.FirstOrDefaultAsync(u => u.SceneryId == idScenery);
        }


        public async Task<SceneryModel> CreateScenery(string NameScenery, string DescriptionScenery, int DifficultyLevel, string Location, DateTime CreationDate, bool Active)
        {
            SceneryModel newScenery = new SceneryModel
            {
                NameScenery = NameScenery,
                DescriptionScenery = DescriptionScenery,
                DifficultyLevel = DifficultyLevel,
                Location = Location,
                CreationDate = CreationDate,
                Active = Active
            };

            await _db.Sceneries.AddAsync(newScenery);
            _db.SaveChangesAsync();
            return newScenery;
        }

        public async Task<SceneryModel> DeleteScenery(SceneryModel scenery)
        {
            _db.Sceneries.Update(scenery);
            await _db.SaveChangesAsync();
            return scenery;
        }
        public async Task<SceneryModel> UpdateScenery(SceneryModel scenery)
        {
            _db.Sceneries.Update(scenery);
            await _db.SaveChangesAsync();
            return scenery;
        }
    }
}
