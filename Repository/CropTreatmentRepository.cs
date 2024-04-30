using Game_Unity.Context;
using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;
using System;

namespace Game_Unity.Repository
{
    public interface ICropTreatmentRepository
    {
        Task<List<CropTreatmentModel>> GetAll();
        Task<CropTreatmentModel> GetCropTreatment(int idCropTreatment);
        Task<CropTreatmentModel> CreateCropTreatment
        (int CropId, int FertilizerId, string TypeTreatment, DateTime DateTreatment, string ProductUsed, decimal QuantityUsed, string ApplicationMethod, string Observations, bool Active);
        Task<CropTreatmentModel> UpdateCropTreatment(CropTreatmentModel cropTreatment);
        Task<CropTreatmentModel> DeleteCropTreatment(CropTreatmentModel cropTreatment);
    }
    public class CropTreatmentRepository: ICropTreatmentRepository
    {
        private readonly CropTreatmentContext _db;
        public CropTreatmentRepository(CropTreatmentContext db)
        {
            _db = db;
        }
        public async Task<List<CropTreatmentModel>> GetAll()
        {
            return await _db.CropTreatments.ToListAsync();
        }

        public async Task<CropTreatmentModel> GetCropTreatment(int idCropTreatment)
        {
            return await _db.CropTreatments.FirstOrDefaultAsync(u => u.CropTreatmentId == idCropTreatment);
        }
        public async Task<CropTreatmentModel> CreateCropTreatment(int CropId, int FertilizerId, string TypeTreatment, DateTime DateTreatment, string ProductUsed, decimal QuantityUsed, string ApplicationMethod, string Observations, bool Active)
        {
            CropTreatmentModel newCropTreatment = new CropTreatmentModel
            {
              CropId = CropId,
              FertilizerId = FertilizerId,
              TypeTreatment = TypeTreatment,
              DateTreatment = DateTreatment,
              ProductUsed = ProductUsed,
              QuantityUsed = QuantityUsed,
              ApplicationMethod = ApplicationMethod,
              Observations = Observations,
              Active = Active
            };

            await _db.CropTreatments.AddAsync(newCropTreatment);
            _db.SaveChangesAsync();
            return newCropTreatment;
        }

        public async Task<CropTreatmentModel> DeleteCropTreatment(CropTreatmentModel cropTreatment)
        {
            _db.CropTreatments.Update(cropTreatment);
            await _db.SaveChangesAsync();
            return cropTreatment;
        }
        public async Task<CropTreatmentModel> UpdateCropTreatment(CropTreatmentModel cropTreatment)
        {
            _db.CropTreatments.Update(cropTreatment);
            await _db.SaveChangesAsync();
            return cropTreatment;
        }
    }
}
