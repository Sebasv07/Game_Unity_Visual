using Game_Unity.Context;
using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Game_Unity.Repository
{
    public interface IDetectiveRepository
    {
        Task<List<DetectiveModel>> GetAll();
        Task<DetectiveModel> GetDetective(int idDetective);
        Task<DetectiveModel> CreateDetective
        (String NameDetective, string Skills, string Description, DateTime DateCreation, bool Active);
        Task<DetectiveModel> UpdateDetective(DetectiveModel detective);
        Task<DetectiveModel> DeleteDetective(DetectiveModel detective);
    }
    public class DetectiveRepository: IDetectiveRepository
    {
        private readonly DetectiveContext _db;
        public DetectiveRepository(DetectiveContext db)
        {
            _db = db;
        }

        public async Task<List<DetectiveModel>> GetAll()
        {
            return await _db.Detectives.ToListAsync();
        }

        public async Task<DetectiveModel> GetDetective(int idDetective)
        {
            return await _db.Detectives.FirstOrDefaultAsync(u => u.DetectiveId == idDetective);
        }

        public async Task<DetectiveModel> CreateDetective(string NameDetective, string Skills, string Description, DateTime DateCreation, bool Active)
        {
            DetectiveModel newDetective = new DetectiveModel
            {
                NameDetective = NameDetective,
                Skills = Skills,
                Description = Description,
                DateCreation = DateCreation,
                Active = Active
            };

            await _db.Detectives.AddAsync(newDetective);
            _db.SaveChangesAsync();
            return newDetective;
        }

        public async Task<DetectiveModel> DeleteDetective(DetectiveModel detective)
        {
            _db.Detectives.Update(detective);
            await _db.SaveChangesAsync();
            return detective;
        }
        public async Task<DetectiveModel> UpdateDetective(DetectiveModel detective)
        {
            _db.Detectives.Update(detective);
            await _db.SaveChangesAsync();
            return detective;
        }
    }
}
