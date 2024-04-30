using Game_Unity.Context;
using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;

namespace Game_Unity.Repository
{
    public interface IMaturationMonitoringRepository
    {
        Task<List<MaturationMonitoringModel>> GetAll();
        Task<MaturationMonitoringModel> GetMaturationMonitoring(int idMaturationMonitoring);
        Task<MaturationMonitoringModel> CreateGetMaturationMonitoring
            (int CropId, DateTime EstimatedRipeningDate, DateTime EstimatedPlanningDate, string MaturationState, string Observations, bool Active);

        Task<MaturationMonitoringModel> UpdateGetMaturationMonitoring(MaturationMonitoringModel maturationMonitoring);
        Task<MaturationMonitoringModel> DeleteGetMaturationMonitoring(MaturationMonitoringModel maturationMonitoring);
    }

    public class MaturationMonitoringRepository: IMaturationMonitoringRepository
    {
        private readonly MaturationMonitoringContext _db;
        public MaturationMonitoringRepository(MaturationMonitoringContext db)
        {
            _db = db;
        }
        public async Task<List<MaturationMonitoringModel>> GetAll()
        {
            return await _db.MaturationMonitorings.ToListAsync();
        }

        public async Task<MaturationMonitoringModel> GetMaturationMonitoring(int idMaturationMonitoring)
        {
            return await _db.MaturationMonitorings.FirstOrDefaultAsync(u => u.MaturationMonitoringId == idMaturationMonitoring);
        }
        public async Task<MaturationMonitoringModel> CreateGetMaturationMonitoring(int CropId, DateTime EstimatedRipeningDate, DateTime EstimatedPlanningDate, string MaturationState, string Observations, bool Active)
        {
            MaturationMonitoringModel newMaturationMonitoring = new MaturationMonitoringModel
            {
              CropId = CropId,
              EstimatedRipeningDate = EstimatedRipeningDate,
              EstimatedPlanningDate = EstimatedPlanningDate,
              MaturationState = MaturationState,
              Observations = Observations,
              Active = Active
            };

            await _db.MaturationMonitorings.AddAsync(newMaturationMonitoring);
            _db.SaveChangesAsync();
            return newMaturationMonitoring;
        }

        public async Task<MaturationMonitoringModel> DeleteGetMaturationMonitoring(MaturationMonitoringModel maturationMonitoring)
        {
            _db.MaturationMonitorings.Update(maturationMonitoring);
            await _db.SaveChangesAsync();
            return maturationMonitoring;
        }
        public async Task<MaturationMonitoringModel> UpdateGetMaturationMonitoring(MaturationMonitoringModel maturationMonitoring)
        {
            _db.MaturationMonitorings.Update(maturationMonitoring);
            await _db.SaveChangesAsync();
            return maturationMonitoring;
        }
    }
}
