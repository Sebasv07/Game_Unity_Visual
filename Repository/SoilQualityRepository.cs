using Game_Unity.Context;
using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Game_Unity.Repository
{
    public interface ISoilQualityRepository
    {
        Task<List<SoilQualityModel>> GetAll();
        Task<SoilQualityModel> GetSoilQuality(int idSoilQuality);
        Task<SoilQualityModel> CreateSoilQuality
         (string TypeSoilQuality, string NutrientLevel, decimal PH, string Description, bool Active);

        Task<SoilQualityModel> UpdateSoilQuality(SoilQualityModel soilQuality);
        Task<SoilQualityModel> DeleteSoilQuality(SoilQualityModel soilQuality);

    }


    public class SoilQualityRepository: ISoilQualityRepository
    {
        private readonly SoilQualityContext _db;

        public SoilQualityRepository(SoilQualityContext db)
        {
            _db = db;
        }

        public async Task<List<SoilQualityModel>> GetAll()
        {
            return await _db.SoilQualitys.ToListAsync();
        }

        public async Task<SoilQualityModel> GetSoilQuality(int idSoilQuality)
        {
            return await _db.SoilQualitys.FirstOrDefaultAsync(u => u.SoilQualityId== idSoilQuality);
        }

        public async Task<SoilQualityModel> CreateSoilQuality(string TypeSoilQuality, string NutrientLevel, decimal PH, string Description, bool Active)
        {
            SoilQualityModel newSoilQuality = new SoilQualityModel
            {
                TypeSoilQuality = TypeSoilQuality,
                NutrientLevel = NutrientLevel,
                PH = PH,
                Description = Description,
                Active = Active
            };

            await _db.SoilQualitys.AddAsync(newSoilQuality);
            await _db.SaveChangesAsync();
            return newSoilQuality;
        }

        public async Task<SoilQualityModel> DeleteSoilQuality(SoilQualityModel soilQuality)
        {
            _db.SoilQualitys.Update(soilQuality);
            await _db.SaveChangesAsync();
            return soilQuality;
        }
        public async Task<SoilQualityModel> UpdateSoilQuality(SoilQualityModel soilQuality)
        {
            _db.SoilQualitys.Update(soilQuality);
            await _db.SaveChangesAsync();
            return soilQuality;
        }
    }
}
