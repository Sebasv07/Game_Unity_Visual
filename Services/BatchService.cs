using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Services
{
    public interface IBatchService
    {
        Task<List<BatchModel>> GetAll();
        Task<BatchModel> GetBatch(int IdBatch);
        Task<BatchModel> CreateBatch
            (string Location, int Size, string SoilType, string Descripcion);
        Task<BatchModel> UpdateBatch
            (int BacnetId, string ? Location, int ? Size, string ? SoilType, string ? Descripcion);
        Task<BatchModel> DeleteBatch(int IdBatch, bool Active);
    }


    public class BatchService: IBatchService
    {
        public readonly IBatchRepository _batchRepository;
        public BatchService(IBatchRepository batchRepository)
        {
            _batchRepository = batchRepository;
        }

        public async Task<List<BatchModel>> GetAll()
        {
            return await _batchRepository.GetAll();
        }

        public async Task<BatchModel> GetBatch(int IdBatch)
        {
            return await _batchRepository.Getbatch(IdBatch);
        }
        public async Task<BatchModel> CreateBatch(string Location, int Size, string SoilType, string Descripcion)
        {
            return await _batchRepository.Createbatch(Location, Size, SoilType, Descripcion, true);
        }

        public async Task<BatchModel> DeleteBatch(int IdBatch, bool Active)
        {
            BatchModel BatchToDelete = await _batchRepository.Getbatch(IdBatch);

            if (BatchToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                BatchToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _batchRepository.Updatebatch(BatchToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("Batch not found.");
            }
        }

        public async Task<BatchModel> UpdateBatch(int BacnetId, string? Location, int? Size, string? SoilType, string? Descripcion)
        {
            BatchModel newBatch = await _batchRepository.Getbatch(BacnetId);
            if (newBatch != null)
            {
                if (newBatch != null)
                {
                   // newBatch.BacnetId = BacnetId;
                    newBatch.Location = Location;
                    newBatch.Size = Size;
                    newBatch.SoilType = SoilType;
                    newBatch.Descripcion = Descripcion;
                }
                return await _batchRepository.Updatebatch(newBatch);
            }
            throw new NotImplementedException();
        }
    }
}
