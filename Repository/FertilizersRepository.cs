using Game_Unity.Context;
using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Game_Unity.Repository
{
    public interface IFertilizersRepository
    {
        Task<List<FertilizersModel>> GetAll();
        Task<FertilizersModel> GetFertilizers(int idFertilizers);
        Task<FertilizersModel> CreateFertilizers
        (string NameFertilizert, string Description, bool Active);
        Task<FertilizersModel> UpdateFertilizers(FertilizersModel fertilizer);
        Task<FertilizersModel> DeleteFertilizers(FertilizersModel fertilizer);
    }

    public class FertilizersRepository: IFertilizersRepository
    {
        private readonly FertilizersContext _db;
        public FertilizersRepository(FertilizersContext db)
        {
            _db = db;
        }

        public async Task<List<FertilizersModel>> GetAll()
        {
            return await _db.Fertilizers.ToListAsync();
        }

        public async Task<FertilizersModel> GetFertilizers(int idFertilizers)
        {
            return await _db.Fertilizers.FirstOrDefaultAsync(u => u.FertilizerId == idFertilizers);
        }

        public async Task<FertilizersModel> CreateFertilizers(string NameFertilizert, string Description, bool Active)
        {
            FertilizersModel newFertilizers = new FertilizersModel
            {
              NameFertilizert = NameFertilizert,
              Description = Description,
              Active = Active
            };

            await _db.Fertilizers.AddAsync(newFertilizers);
            _db.SaveChangesAsync();
            return newFertilizers;
        }

        public async Task<FertilizersModel> DeleteFertilizers(FertilizersModel fertilizer)
        {
            _db.Fertilizers.Update(fertilizer);
            await _db.SaveChangesAsync();
            return fertilizer;
        }
        public async Task<FertilizersModel> UpdateFertilizers(FertilizersModel fertilizer)
        {
            _db.Fertilizers.Update(fertilizer);
            await _db.SaveChangesAsync();
            return fertilizer;
        }
    }
}
