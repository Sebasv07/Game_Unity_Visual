using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Services
{
    public interface IMaturationMonitoringService
    {
        Task<List<MaturationMonitoringModel>> GetAll();
        Task<MaturationMonitoringModel> GetMaturationMonitoring(int IdMaturationMonitoring);
        Task<MaturationMonitoringModel> CreateMaturationMonitoring
            (int CropId, DateTime EstimatedRipeningDate, DateTime EstimatedPlanningDate, string MaturationState, string Observations, bool Active);
        Task<MaturationMonitoringModel> UpdateMaturationMonitoring
            (int MaturationMonitoringId, int ? CropId, DateTime ? EstimatedRipeningDate, DateTime ? EstimatedPlanningDate, string ? MaturationState, string ? Observations, bool Active);
        Task<MaturationMonitoringModel> DeleteMaturationMonitoring(int IdMaturationMonitoring, bool Active);

    }

    public class MaturationMonitoringService: IMaturationMonitoringService
    {
        public readonly IMaturationMonitoringRepository _imaturationMonitoringRepository;
        public MaturationMonitoringService(IMaturationMonitoringRepository maturationMonitoringRepository)
        {
            _imaturationMonitoringRepository = maturationMonitoringRepository;
        }
        public async  Task<List<MaturationMonitoringModel>> GetAll()
        {
            return await _imaturationMonitoringRepository.GetAll();
        }

        public async Task<MaturationMonitoringModel> GetMaturationMonitoring(int IdMaturationMonitoring)
        {
            return await _imaturationMonitoringRepository.GetMaturationMonitoring(IdMaturationMonitoring);
        }

        public async Task<MaturationMonitoringModel> CreateMaturationMonitoring(int CropId, DateTime EstimatedRipeningDate, DateTime EstimatedPlanningDate, string MaturationState, string Observations, bool Active)
        {
            return await _imaturationMonitoringRepository.CreateGetMaturationMonitoring(CropId, EstimatedRipeningDate, EstimatedPlanningDate, MaturationState, Observations, Active);
        }

        public async Task<MaturationMonitoringModel> DeleteMaturationMonitoring(int IdMaturationMonitoring, bool Active)
        {
            MaturationMonitoringModel MaturationMonitoringToDelete = await _imaturationMonitoringRepository.GetMaturationMonitoring(IdMaturationMonitoring);

            if (MaturationMonitoringToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                MaturationMonitoringToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _imaturationMonitoringRepository.UpdateGetMaturationMonitoring(MaturationMonitoringToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("MaturationMonitoring not found.");
            }
        }

        public async Task<MaturationMonitoringModel> UpdateMaturationMonitoring(int MaturationMonitoringId, int? CropId, DateTime? EstimatedRipeningDate, DateTime? EstimatedPlanningDate, string? MaturationState, string? Observations, bool Active)
        {
            MaturationMonitoringModel newMaturationMonitoring = await _imaturationMonitoringRepository.GetMaturationMonitoring(MaturationMonitoringId);
            if (newMaturationMonitoring != null)
            {
                if (newMaturationMonitoring != null)
                {
                    //newMaturationMonitoring.MaturationMonitoringId = MaturationMonitoringId;
                    newMaturationMonitoring.CropId = CropId;
                    newMaturationMonitoring.EstimatedRipeningDate = EstimatedRipeningDate;
                    newMaturationMonitoring.EstimatedPlanningDate = EstimatedPlanningDate;
                    newMaturationMonitoring.MaturationState = MaturationState;
                    newMaturationMonitoring.Observations = Observations;
                    newMaturationMonitoring.Active = Active;

                }
                return await _imaturationMonitoringRepository.UpdateGetMaturationMonitoring(newMaturationMonitoring);
            }
            throw new NotImplementedException();
        }
    }
}
