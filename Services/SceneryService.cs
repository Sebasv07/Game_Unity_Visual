using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Services
{
    public interface ISceneryService
    {
        Task<List<SceneryModel>> GetAll();
        Task<SceneryModel> GetScenery(int IdScenery);
        Task<SceneryModel> CreateScenery
            (string NameScenery, string DescriptionScenery, int DifficultyLevel, string Location, DateTime CreationDate, bool Active);
        Task<SceneryModel> UpdateScenery
            (int SceneryId, string ? NameScenery, string? DescriptionScenery, int? DifficultyLevel, string ? Location, DateTime? CreationDate, bool Active);
        Task<SceneryModel> DeleteScenery(int IdScenery, bool Active);

    }

    public class SceneryService:ISceneryService
    {
        public readonly IScenaryRepository _iscenaryrepository;
        public SceneryService(IScenaryRepository iscenaryRepository)
        {
            _iscenaryrepository = iscenaryRepository;
        }

        public async Task<List<SceneryModel>> GetAll()
        {
            return await _iscenaryrepository.GetAll();
        }

        public async Task<SceneryModel> GetScenery(int IdScenery)
        {
            return await _iscenaryrepository.GetScenery(IdScenery);
        }

        public async Task<SceneryModel> CreateScenery(string NameScenery, string DescriptionScenery, int DifficultyLevel, string Location, DateTime CreationDate, bool Active)
        {
            return await _iscenaryrepository.CreateScenery(NameScenery, DescriptionScenery, DifficultyLevel, Location, CreationDate, Active);
        }

        public async Task<SceneryModel> DeleteScenery(int IdScenery, bool Active)
        {
            SceneryModel SceneryToDelete = await _iscenaryrepository.GetScenery(IdScenery);

            if (SceneryToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                SceneryToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _iscenaryrepository.UpdateScenery(SceneryToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("Scenary not found.");
            }
        }
        public async Task<SceneryModel> UpdateScenery(int SceneryId, string? NameScenery, string? DescriptionScenery, int? DifficultyLevel, string? Location, DateTime? CreationDate, bool Active)
        {
            SceneryModel newScenery = await _iscenaryrepository.GetScenery(SceneryId);
            if (newScenery != null)
            {
                if (newScenery != null)
                {
                    //newScenery.SceneryId = SceneryId;
                    newScenery.NameScenery = NameScenery;
                    newScenery.DescriptionScenery = DescriptionScenery;
                    newScenery.DifficultyLevel = DifficultyLevel;
                    newScenery.Location = Location;
                    newScenery.CreationDate = (DateTime)CreationDate;
                    newScenery.Active = Active;
                }
                return await _iscenaryrepository.UpdateScenery(newScenery);
            }
            throw new NotImplementedException();
        }
    }
}
