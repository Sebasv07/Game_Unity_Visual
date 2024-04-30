using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Services
{
    public interface IDetectiveService
    {
        Task<List<DetectiveModel>> GetAll();
        Task<DetectiveModel> GetDetective(int IdDetective);
        Task<DetectiveModel> CreateDetective
            (String NameDetective, string Skills, string Description, DateTime DateCreation, bool Active);
        Task<DetectiveModel> UpdateDetective
            (int DetectiveId, String ? NameDetective, string?  Skills, string?  Description, DateTime? DateCreation, bool Active);
        Task<DetectiveModel> DeleteDetective(int IdDetective, bool Active);

    }

    public class DetectiveService:IDetectiveService
    {
        public readonly IDetectiveRepository _detectiveRepository;
        public DetectiveService(IDetectiveRepository detectiveRepository)
        {
            _detectiveRepository = detectiveRepository;
        }

        public async Task<List<DetectiveModel>> GetAll()
        {
            return await _detectiveRepository.GetAll();
        }

        public async Task<DetectiveModel> GetDetective(int IdDetective)
        {
            return await _detectiveRepository.GetDetective(IdDetective);
        }
        public async Task<DetectiveModel> CreateDetective(string NameDetective, string Skills, string Description, DateTime DateCreation, bool Active)
        {
            return await _detectiveRepository.CreateDetective(NameDetective, Skills, Description, DateCreation, true);
        }

        public async Task<DetectiveModel> DeleteDetective(int IdDetective, bool Active)
        {
            DetectiveModel DetectiveToDelete = await _detectiveRepository.GetDetective(IdDetective);

            if (DetectiveToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                DetectiveToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _detectiveRepository.UpdateDetective(DetectiveToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("Detective not found.");
            }
        }

        public async Task<DetectiveModel> UpdateDetective(int DetectiveId, string? NameDetective, string? Skills, string? Description, DateTime? DateCreation, bool Active)
        {
            DetectiveModel newDetective= await _detectiveRepository.GetDetective(DetectiveId);
            if (newDetective != null)
            {
                if (newDetective != null)
                {
                    //newDetective.DetectiveId = DetectiveId;
                    newDetective.NameDetective = NameDetective;
                    newDetective.Skills = Skills;
                    newDetective.Description = Description;
                    newDetective.DateCreation = DateCreation;
                  //  newDetective.Active = Active;
                }
                return await _detectiveRepository.UpdateDetective(newDetective);
            }
            throw new NotImplementedException();
        }
    }
}
