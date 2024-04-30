using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Services
{
    public interface IDetectiveCluesService
    {
        Task<List<DetectiveCluesModel>> GetAll();
        Task<DetectiveCluesModel> GetDetectiveClues(int IdDetectiveClues);
        Task<DetectiveCluesModel> CreateDetectiveClues
            (int DetectiveId, string Description, string Type, DateTime CollectionDate, bool SolutionMistery, bool Active);
        Task<DetectiveCluesModel> UpdateDetectiveClues
            (int DetectiveCluesId, int? DetectiveId, string ?Description, string ? Type, DateTime? CollectionDate, bool ? SolutionMistery, bool Active);
        Task<DetectiveCluesModel> DeleteDetectiveClues(int IdDetectiveClues, bool Active);

    }


    public class DetectiveCluesService: IDetectiveCluesService
    {
        public readonly IDetectiveCluesRepository _detectiveCluesRepository;
        public DetectiveCluesService(IDetectiveCluesRepository detectiveCluesRepository)
        {
            _detectiveCluesRepository = detectiveCluesRepository;
        }
        public async Task<List<DetectiveCluesModel>> GetAll()
        {
            return await _detectiveCluesRepository.GetAll();
        }

        public async Task<DetectiveCluesModel> GetDetectiveClues(int IdDetectiveClues)
        {
            return await _detectiveCluesRepository.GetDetectiveClues(IdDetectiveClues);
        }
        public async Task<DetectiveCluesModel> CreateDetectiveClues(int DetectiveId, string Description, string Type, DateTime CollectionDate, bool SolutionMistery, bool Active)
        {
            return await _detectiveCluesRepository.CreateDetectiveClues(DetectiveId, Description, Type, CollectionDate, SolutionMistery, true);
        }

        public async Task<DetectiveCluesModel> DeleteDetectiveClues(int IdDetectiveClues, bool Active)
        {
            DetectiveCluesModel DetectiveClueToDelete = await _detectiveCluesRepository.GetDetectiveClues(IdDetectiveClues);

            if (DetectiveClueToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                DetectiveClueToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _detectiveCluesRepository.UpdateDetectiveClues(DetectiveClueToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("DetectiveClues not found.");
            }
        }

        public async Task<DetectiveCluesModel> UpdateDetectiveClues(int DetectiveCluesId, int? DetectiveId, string? Description, string? Type, DateTime? CollectionDate, bool? SolutionMistery, bool Active)
        {
            DetectiveCluesModel newDetectiveClues = await _detectiveCluesRepository.GetDetectiveClues(DetectiveCluesId);
            if (newDetectiveClues != null)
            {
                if (newDetectiveClues != null)
                {
                    newDetectiveClues.DetectiveCluesId = DetectiveCluesId;
                    newDetectiveClues.DetectiveId = (int)DetectiveId;
                    newDetectiveClues.Description = Description;
                    newDetectiveClues.Type = Type;
                    newDetectiveClues.CollectionDate = CollectionDate;
                    newDetectiveClues.SolutionMistery = SolutionMistery;
                   // newDetectiveClues.Active = Active;

                }
                return await _detectiveCluesRepository.UpdateDetectiveClues(newDetectiveClues);
            }
            throw new NotImplementedException();
        }
    }
}
