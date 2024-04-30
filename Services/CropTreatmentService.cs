using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Services
{
    public interface ICropTreatmentService
    {
        Task<List<CropTreatmentModel>> GetAll();
        Task<CropTreatmentModel> GetCropTreatment(int IdCropTreatment);
        Task<CropTreatmentModel> CreateCropTreatment
            (int CropId, int FertilizerId, string TypeTreatment, DateTime DateTreatment, string ProductUsed, decimal QuantityUsed, string ApplicationMethod, string Observations, bool Active);
        Task<CropTreatmentModel> UpdateCropTreatment
            (int CropTreatmentId, int ? CropId, int ? FertilizerId, string ? TypeTreatment, DateTime ? DateTreatment, string ? ProductUsed, decimal ? QuantityUsed, string ? ApplicationMethod, string ? Observations);
        Task<CropTreatmentModel> DeleteCropTreatment(int IdCropTreatment, bool Active);

    }


    public class CropTreatmentService: ICropTreatmentService
    {
        public readonly ICropTreatmentRepository _cropTreatmentRepository;
        public CropTreatmentService(ICropTreatmentRepository cropTreatmentRepository)
        {
            _cropTreatmentRepository = cropTreatmentRepository;
        }
        public async Task<List<CropTreatmentModel>> GetAll()
        {
            return await _cropTreatmentRepository.GetAll();
        }

        public async Task<CropTreatmentModel> GetCropTreatment(int IdCropTreatment)
        {
            return await _cropTreatmentRepository.GetCropTreatment(IdCropTreatment);
        }

        public async Task<CropTreatmentModel> CreateCropTreatment(int CropId, int FertilizerId, string TypeTreatment, DateTime DateTreatment, string ProductUsed, decimal QuantityUsed, string ApplicationMethod, string Observations, bool Active)
        {
            return await _cropTreatmentRepository.CreateCropTreatment(CropId, FertilizerId, TypeTreatment, DateTreatment, ProductUsed, QuantityUsed, ApplicationMethod, Observations, true);
        }

        public async Task<CropTreatmentModel> DeleteCropTreatment(int IdCropTreatment, bool Active)
        {
            CropTreatmentModel CropTreatmentToDelete = await _cropTreatmentRepository.GetCropTreatment(IdCropTreatment);

            if (CropTreatmentToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                CropTreatmentToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _cropTreatmentRepository.UpdateCropTreatment(CropTreatmentToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("CropTreatment not found.");
            }
        }

        public async Task<CropTreatmentModel> UpdateCropTreatment(int CropTreatmentId, int? CropId, int? FertilizerId, string? TypeTreatment, DateTime? DateTreatment, string? ProductUsed, decimal? QuantityUsed, string? ApplicationMethod, string? Observations)
        {
            CropTreatmentModel newCropTreatment = await _cropTreatmentRepository.GetCropTreatment(CropTreatmentId);
            if (newCropTreatment != null)
            {
                if (newCropTreatment != null)
                {
                    // newCropTreatment.CropTreatmentId = CropTreatmentId;
                    newCropTreatment.CropId = CropId;
                    newCropTreatment.FertilizerId = FertilizerId;
                    newCropTreatment.TypeTreatment = TypeTreatment;
                    newCropTreatment.DateTreatment = DateTreatment;
                    newCropTreatment.ProductUsed = ProductUsed;
                    newCropTreatment.QuantityUsed = QuantityUsed;
                    newCropTreatment.ApplicationMethod = ApplicationMethod;
                    newCropTreatment.Observations = Observations;
                }
                return await _cropTreatmentRepository.UpdateCropTreatment(newCropTreatment);
            }
            throw new NotImplementedException();
        }
    }
}
