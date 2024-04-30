using Game_Unity.Context;
using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace Game_Unity.Repository
{
    public interface IBatchRepository
    {
        Task<List<BatchModel>> GetAll();
        Task<BatchModel> Getbatch(int idbatch);
        Task<BatchModel> Createbatch
        (string Location, int Size, string SoilType, string Descripcion, bool Active);
        Task<BatchModel> Updatebatch(BatchModel batch);
        Task<BatchModel> Deletebatch(BatchModel batch);
    }

    public class BatchRepository: IBatchRepository
    {
        private readonly BatchContext _db;
        public BatchRepository(BatchContext db)
        {
            _db = db;
        }

        public async Task<List<BatchModel>> GetAll()
        {
            return await _db.Batches.ToListAsync();
        }

        public async Task<BatchModel> Getbatch(int idbatch)
        {
            return await _db.Batches.FirstOrDefaultAsync(u => u.BachnetId == idbatch);
        }

        public async Task<BatchModel> Createbatch(string Location, int Size, string SoilType, string Descripcion, bool Active)
        {
            BatchModel newBatch = new BatchModel
            {
              Location = Location,
              Size = Size,
              SoilType = SoilType,
              Descripcion = Descripcion,
              Active = Active

            };

            await _db.Batches.AddAsync(newBatch);
            _db.SaveChangesAsync();
            return newBatch;
        }

        public async Task<BatchModel> Deletebatch(BatchModel batch)
        {
            _db.Batches.Update(batch);
            await _db.SaveChangesAsync();
            return batch;
        }
        public async Task<BatchModel> Updatebatch(BatchModel batch)
        {
            _db.Batches.Update(batch);
            await _db.SaveChangesAsync();
            return batch;
        }
    }
}
