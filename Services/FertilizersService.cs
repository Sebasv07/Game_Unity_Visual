using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Services
{

    public interface IFertilizersService
    {
        Task<List<FertilizersModel>> GetAll();
        Task<FertilizersModel> GetFertilizers(int IdFertilizers);
        Task<FertilizersModel> CreateFertilizers
            (string NameFertilizert, string Description, bool Active);
        Task<FertilizersModel> UpdateFertilizers
            (int IdFertilizers, string ? NameFertilizert, string ? Description);
        Task<FertilizersModel> DeleteFertilizers(int IdFertilizers, bool Active);
    }

    public class FertilizersService: IFertilizersService
    {
        public readonly IFertilizersRepository _fertilizersRepository;
        public FertilizersService(IFertilizersRepository ferrtilizersRepository)
        {
            _fertilizersRepository = ferrtilizersRepository;
        }

        public async Task<List<FertilizersModel>> GetAll()
        {
            return await _fertilizersRepository.GetAll();
        }

        public async Task<FertilizersModel> GetFertilizers(int IdFertilizers)
        {
            return await _fertilizersRepository.GetFertilizers(IdFertilizers);
        }

        public async Task<FertilizersModel> CreateFertilizers(string NameFertilizert, string Description, bool Active)
        {
            return await _fertilizersRepository.CreateFertilizers(NameFertilizert,Description,true);
        }

        public async Task<FertilizersModel> DeleteFertilizers(int IdFertilizers, bool Active)
        {
            FertilizersModel FertilizersToDelete = await _fertilizersRepository.GetFertilizers(IdFertilizers);

            if (FertilizersToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                FertilizersToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _fertilizersRepository.UpdateFertilizers(FertilizersToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("Fertilizers not found.");
            }
        }

        public async Task<FertilizersModel> UpdateFertilizers(int IdFertilizers, string? NameFertilizert, string? Description)
        {
            FertilizersModel newFertilizers= await _fertilizersRepository.GetFertilizers(IdFertilizers);
            if (newFertilizers != null)
            {
                if (newFertilizers != null)
                {
                    //newFertilizers.FertilizerId = IdFertilizers;
                    newFertilizers.NameFertilizert = NameFertilizert;
                    newFertilizers.Description = Description;
                }
                return await _fertilizersRepository.UpdateFertilizers(newFertilizers);
            }
            throw new NotImplementedException();
        }
    }
}
