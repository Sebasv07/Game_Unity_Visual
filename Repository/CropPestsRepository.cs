using Game_Unity.Context;
using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace Game_Unity.Repository
{
    public interface ICropPestsRepository
    {
        Task<List<CropPestsModel>> GetAll();
        Task<CropPestsModel> GetCropPests(int idCropPests);
        Task<CropPestsModel> CreateCropPests
        (int Crop, int Plague, bool Active);
        Task<CropPestsModel> UpdateCropPests(CropPestsModel cropPests);
        Task<CropPestsModel> DeleteCropPests(CropPestsModel cropPests);
    }

    public class CropPestsRepository : ICropPestsRepository
    {
        private readonly CropPestsContext _db;
        public CropPestsRepository(CropPestsContext db)
        {
            _db = db;
        }

        public async Task<List<CropPestsModel>> GetAll()
        {
            return await _db.Crop_Pests.ToListAsync();
        }

        public async Task<CropPestsModel> GetCropPests(int idCropPests)
        {
            //return await _db.Crop_Pests.FirstOrDefaultAsync(u => u.cro == idDetective);
            throw new NotImplementedException();
        }
        public async Task<CropPestsModel> CreateCropPests(int Crop, int Plague, bool Active)
        {
            CropPestsModel newCropPests = new CropPestsModel
            {
                Plague = Plague, Active = Active
            };

            await _db.Crop_Pests.AddAsync(newCropPests);
            _db.SaveChangesAsync();
            return newCropPests;
        }

        public async Task<CropPestsModel> DeleteCropPests(CropPestsModel cropPests)
        {
            _db.Crop_Pests.Update(cropPests);
            await _db.SaveChangesAsync();
            return cropPests;
        }
        public async Task<CropPestsModel> UpdateCropPests(CropPestsModel cropPests)
        {
            _db.Crop_Pests.Update(cropPests);
            await _db.SaveChangesAsync();
            return cropPests;
        }
    }
}
