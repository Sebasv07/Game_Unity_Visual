using Game_Unity.Context;
using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace Game_Unity.Repository
{
    public interface ICropRepository
    {
        Task<List<CropModel>> GetAll();
        Task<CropModel> GetCrop(int idCrop);
        Task<CropModel> CreateCrop
        (int BatchId, int UserId, string TypeCrop, string GreetingStatus, string StageGrowth, int ClimaticConditionID, int SoilQualityID, bool Active);
        Task<CropModel> UpdateCrop(CropModel crop);
        Task<CropModel> DeleteCrop(CropModel crop);
    }

    public class CropRepository: ICropRepository
    {
        private readonly CropContext _db;
        public CropRepository(CropContext db)
        {
            _db = db;
        }

        public async Task<List<CropModel>> GetAll()
        {
            return await _db.Crops.ToListAsync();
        }

        public async Task<CropModel> GetCrop(int idCrop)
        {
            return await _db.Crops.FirstOrDefaultAsync(u => u.CropId == idCrop);
        }
        public async Task<CropModel> CreateCrop(int BatchId, int UserId, string TypeCrop, string GreetingStatus, string StageGrowth, int ClimaticConditionID, int SoilQualityID, bool Active)
        {
            CropModel newCrop= new CropModel
            { 
                BatchId = BatchId,
                UserId = UserId,
                TypeCrop = TypeCrop,
                GreetingStatus = GreetingStatus,
                StageGrowth = StageGrowth,
                ClimaticConditionID = ClimaticConditionID,
                SoilQualityID = SoilQualityID,
                Active = Active

            };

            await _db.Crops.AddAsync(newCrop);
            _db.SaveChangesAsync();
            return newCrop;
        }

        public async Task<CropModel> DeleteCrop(CropModel crop)
        {
            _db.Crops.Update(crop);
            await _db.SaveChangesAsync();
            return crop;
        }
        public async Task<CropModel> UpdateCrop(CropModel crop)
        {
            _db.Crops.Update(crop);
            await _db.SaveChangesAsync();
            return crop;
        }
    }
}
