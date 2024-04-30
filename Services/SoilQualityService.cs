using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Services
{
    public interface ISoilQualityService
    {
        Task<List<SoilQualityModel>> GetAll();
        Task<SoilQualityModel> GetSoilQuality(int IdSoilQuality);
        Task<SoilQualityModel> CreateSoilQuality
            (string TypeSoilQuality, string NutrientLevel, decimal PH, string Description, bool Active);
        Task<SoilQualityModel> UpdatSoilQuality
            (int SoilQualityId, string TypeSoilQuality, string NutrientLevel, decimal PH, string Description, bool Active);
        Task<SoilQualityModel> DeleteSoilQuality(int IdSoilQuality, bool Active);

    }

    public class SoilQualityService: ISoilQualityService
    {
        public readonly ISoilQualityRepository _isoilqualityrepository;

        public SoilQualityService(ISoilQualityRepository isoilQualityRepository)
        {
            _isoilqualityrepository = isoilQualityRepository;
        }
        public async Task<List<SoilQualityModel>> GetAll()
        {
            return await _isoilqualityrepository.GetAll();
        }

        public async Task<SoilQualityModel> GetSoilQuality(int IdSoilQuality)
        {
            return await _isoilqualityrepository.GetSoilQuality(IdSoilQuality);
        }

        public async Task<SoilQualityModel> CreateSoilQuality(string TypeSoilQuality, string NutrientLevel, decimal PH, string Description, bool Active)
        {
            return await _isoilqualityrepository.CreateSoilQuality(TypeSoilQuality, NutrientLevel, PH, Description, Active);
        }

        public async Task<SoilQualityModel> DeleteSoilQuality(int IdSoilQuality, bool Active)
        {
            SoilQualityModel SoilQualityToDelete = await _isoilqualityrepository.GetSoilQuality(IdSoilQuality);

            if (SoilQualityToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                SoilQualityToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _isoilqualityrepository.UpdateSoilQuality(SoilQualityToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("SoilQuality not found.");
            }
        }

        public async Task<SoilQualityModel> UpdatSoilQuality(int SoilQualityId, string TypeSoilQuality, string NutrientLevel, decimal PH, string Description, bool Active)
        {
            SoilQualityModel newSoilQuality = await _isoilqualityrepository.GetSoilQuality(SoilQualityId);
            if (newSoilQuality != null)
            {
                if (newSoilQuality != null)
                {
                 //   newSoilQuality.SoilQualityId = SoilQualityId;
                    newSoilQuality.TypeSoilQuality = TypeSoilQuality;
                    newSoilQuality.NutrientLevel = NutrientLevel;
                    newSoilQuality.PH = PH;
                    newSoilQuality.Description = Description;
                    newSoilQuality.Active = Active;
                }
                return await _isoilqualityrepository.UpdateSoilQuality(newSoilQuality);
            }
            throw new NotImplementedException();
        }
    }
}
