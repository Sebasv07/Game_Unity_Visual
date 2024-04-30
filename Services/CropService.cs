using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Services
{
    public interface ICropService
    {
        Task<List<CropModel>> GetAll();
        Task<CropModel> GetCrop(int IdCrop);
        Task<CropModel> CreateCrop
            (int BatchId, int UserId, string TypeCrop, string GreetingStatus, string StageGrowth, int ClimaticConditionID, int SoilQualityID, bool Active);
        Task<CropModel> UpdateCrop
            (int CropId, int ? BatchId, int ? UserId, string ? TypeCrop, string ? GreetingStatus, string ? StageGrowth, int ? ClimaticConditionID, int ? SoilQualityID);
        Task<CropModel> DeleteCrop(int IdCrop, bool Active);

    }

    public class CropService : ICropService
    {
        public readonly ICropRepository _cropRepository;
        public CropService(ICropRepository cropRepository)
        {
            _cropRepository = cropRepository;
        }

        public async Task<List<CropModel>> GetAll()
        {
            return await _cropRepository.GetAll();
        }

        public async Task<CropModel> GetCrop(int IdCrop)
        {
            return await _cropRepository.GetCrop(IdCrop);
        }

        public async Task<CropModel> CreateCrop(int BatchId, int UserId, string TypeCrop, string GreetingStatus, string StageGrowth, int ClimaticConditionID, int SoilQualityID, bool Active)
        {
            return await _cropRepository.CreateCrop(BatchId, UserId, TypeCrop, GreetingStatus, StageGrowth, ClimaticConditionID, SoilQualityID, true);
        }

        public async Task<CropModel> DeleteCrop(int IdCrop, bool Active)
        {
            CropModel CropToDelete = await _cropRepository.GetCrop(IdCrop);

            if (CropToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                CropToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _cropRepository.UpdateCrop(CropToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("Crop not found.");
            }
        }

        public async Task<CropModel> UpdateCrop(int CropId, int? BatchId, int? UserId, string? TypeCrop, string? GreetingStatus, string? StageGrowth, int? ClimaticConditionID, int? SoilQualityID)
        {
            CropModel newCrop = await _cropRepository.GetCrop(CropId);
            if (newCrop != null)
            {
                if (newCrop != null)
                {
                    //newCrop.CropId = CropId;
                    newCrop.BatchId = BatchId;
                    newCrop.UserId = UserId;
                    newCrop.TypeCrop = TypeCrop;
                    newCrop.GreetingStatus = GreetingStatus;
                    newCrop.StageGrowth = StageGrowth;
                    newCrop.ClimaticConditionID = ClimaticConditionID;
                    newCrop.SoilQualityID = SoilQualityID;
                }
                return await _cropRepository.UpdateCrop(newCrop);
            }
            throw new NotImplementedException();
        }
    }
}
