using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Services
{
    public interface IPlagueService
    {
        Task<List<PlagueModel>> GetAll();
        Task<PlagueModel> GetPlague(int IdPlague);
        Task<PlagueModel> CreatePlague
            (string NamePlague, string Description, bool Active);
        Task<PlagueModel> UpdatePlague
            (int PlagueId, string? NamePlague, string? Description, bool Active);
        Task<PlagueModel> DeletePlague(int IdPlague ,bool Active);

    }
    public class PlagueService: IPlagueService
    {
        public readonly IPlagueRepository _iplaguerepository;
        public PlagueService(IPlagueRepository iplagueRepository)
        {
            _iplaguerepository = iplagueRepository;
        }

        public async Task<List<PlagueModel>> GetAll()
        {
            return await _iplaguerepository.GetAll();
        }

        public async Task<PlagueModel> GetPlague(int IdPlague)
        {
            return await _iplaguerepository.GetPlague(IdPlague);
        }

        public async Task<PlagueModel> CreatePlague(string NamePlague, string Description, bool Active)
        {
            return await _iplaguerepository.CreatePlague(NamePlague, Description, Active);
        }

        public async Task<PlagueModel> DeletePlague(int IdPlague, bool Active)
        {
            PlagueModel PlagueToDelete = await _iplaguerepository.GetPlague(IdPlague);

            if (PlagueToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                PlagueToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _iplaguerepository.UpdatePlague(PlagueToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("Plague not found.");
            }
        }
        public async Task<PlagueModel> UpdatePlague(int PlagueId, string? NamePlague, string? Description, bool Active)
        {
            PlagueModel newPlague = await _iplaguerepository.GetPlague(PlagueId);
            if (newPlague != null)
            {
                if (newPlague != null)
                {
                    //newPlague.PlagueId = PlagueId;
                    newPlague.NamePlague = NamePlague;
                    newPlague.Description = Description;
                    newPlague.Active = Active;
                }
                return await _iplaguerepository.UpdatePlague(newPlague);
            }
            throw new NotImplementedException();
        }
    }
}
