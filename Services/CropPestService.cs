using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Services
{
    public interface ICropPestService
    {
        Task<List<CropPestsModel>> GetAll();
        Task<CropPestsModel> GetCropPest(int IdUCropPest);
        Task<CropPestsModel> CreateCropPest
            (int crop, int Plague, bool Active);
        Task<CropPestsModel> UpdateCropPest
            (int Crop, int? Plague);
        Task<CropPestsModel> DeleteCropPest(int IdCropPest, bool Active);

    }

    public class CropPestService:ICropPestService
    {
        public readonly ICropPestsRepository _cropPestsRepository;
        public CropPestService(ICropPestsRepository cropPestsRepository)
        {
            _cropPestsRepository = cropPestsRepository;
        }

        public async Task<List<CropPestsModel>> GetAll()
        {
            return await _cropPestsRepository.GetAll();
        }

        public async Task<CropPestsModel> GetCropPest(int IdUCropPest)
        {
           return await _cropPestsRepository.GetCropPests(IdUCropPest);
        }
        public async Task<CropPestsModel> CreateCropPest(int Crop, int Plague, bool Active)
        {
            return await _cropPestsRepository.CreateCropPests(Crop, Plague, Active);
        }

        public async Task<CropPestsModel> DeleteCropPest(int IdCropPest, bool Active)
        {
            CropPestsModel CropPestsToDelete = await _cropPestsRepository.GetCropPests(IdCropPest);

            if (CropPestsToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                CropPestsToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _cropPestsRepository.UpdateCropPests(CropPestsToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("CropPests not found.");
            }
        }

        public async Task<CropPestsModel> UpdateCropPest(int Crop, int? Plague)
        {
            CropPestsModel newCropPests = await _cropPestsRepository.GetCropPests(Crop);
            if (newCropPests != null)
            {
                if (newCropPests != null)
                {
                    newCropPests.Crop = Crop;
                    newCropPests.Plague = Plague;
                }
                return await _cropPestsRepository.UpdateCropPests(newCropPests);
            }
            throw new NotImplementedException();
        }
    }
}
