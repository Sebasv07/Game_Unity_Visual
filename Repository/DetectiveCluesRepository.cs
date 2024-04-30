using Game_Unity.Context;
using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace Game_Unity.Repository
{
    public interface IDetectiveCluesRepository
    {
        Task<List<DetectiveCluesModel>> GetAll();
        Task<DetectiveCluesModel> GetDetectiveClues(int idDetectiveClues);
        Task<DetectiveCluesModel> CreateDetectiveClues
        (int DetectiveId, string Description, string Type, DateTime CollectionDate, bool SolutionMistery, bool Active);
        Task<DetectiveCluesModel> UpdateDetectiveClues(DetectiveCluesModel detectiveclues);
        Task<DetectiveCluesModel> DeleteDetectiveClues(DetectiveCluesModel detectiveclues);
    }

    public class DetectiveCluesRepository: IDetectiveCluesRepository
    {
        private readonly DetectiveCluesContext _db;
        public DetectiveCluesRepository(DetectiveCluesContext db)
        {
            _db = db;
        }
        public async Task<List<DetectiveCluesModel>> GetAll()
        {
            return await _db.DetectiveClues.ToListAsync();
        }

        public async Task<DetectiveCluesModel> GetDetectiveClues(int idDetectiveClues)
        {
            return await _db.DetectiveClues.FirstOrDefaultAsync(u => u.DetectiveCluesId == idDetectiveClues);
        }
        public async Task<DetectiveCluesModel> CreateDetectiveClues(int DetectiveId, string Description, string Type, DateTime CollectionDate, bool SolutionMistery, bool Active)
        {
            DetectiveCluesModel newDetectiveClues = new DetectiveCluesModel
            {
             DetectiveId = DetectiveId,
             Description = Description,
             Type = Type,
             CollectionDate = CollectionDate,
             SolutionMistery = SolutionMistery,
             Active = Active
            };

            await _db.DetectiveClues.AddAsync(newDetectiveClues);
            _db.SaveChangesAsync();
            return newDetectiveClues;
        }

        public async Task<DetectiveCluesModel> DeleteDetectiveClues(DetectiveCluesModel detectiveclues)
        {
            _db.DetectiveClues.Update(detectiveclues);
            await _db.SaveChangesAsync();
            return detectiveclues;
        }
        public async Task<DetectiveCluesModel> UpdateDetectiveClues(DetectiveCluesModel detectiveclues)
        {
            _db.DetectiveClues.Update(detectiveclues);
            await _db.SaveChangesAsync();
            return detectiveclues;
        }
    }

}
