using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Services
{
    public interface IAvatarLocationService
    {
        Task<List<AvatarLocationModel>> GetAll();
        Task<AvatarLocationModel> GetAvatarLocation(int IdAvatarLocation);
        Task<AvatarLocationModel> CreateAvatarLocation
            (int GameId, int DetectiveId, decimal CoordinatesX, decimal CoordinatesY, decimal CoordinatesZ, bool Active);
        Task<AvatarLocationModel> UpdateAvatarLocation
            (int AvatarLocationId, int ? GameId, int ? DetectiveId, decimal ? CoordinatesX, decimal ? CoordinatesY, decimal ? CoordinatesZ);
        Task<AvatarLocationModel> DeleteAvatarLocation(int IdAvatarLocation, bool Active);
    }


    public class AvatarLocationService: IAvatarLocationService
    {
        public readonly IAvatarLocationRepository _avatarLocationRepository;
        public AvatarLocationService(IAvatarLocationRepository avatarLocationRepository)
        {
            _avatarLocationRepository = avatarLocationRepository;
        }

        public async Task<List<AvatarLocationModel>> GetAll()
        {
            return await _avatarLocationRepository.GetAll();
        }

        public async Task<AvatarLocationModel> GetAvatarLocation(int IdAvatarLocation)
        {
            return await _avatarLocationRepository.GetavatarLocation(IdAvatarLocation);
        }
        public async Task<AvatarLocationModel> CreateAvatarLocation(int GameId, int DetectiveId, decimal CoordinatesX, decimal CoordinatesY, decimal CoordinatesZ, bool Active)
        {
            return await _avatarLocationRepository.CreateavatarLocation(GameId, DetectiveId, CoordinatesX, CoordinatesY, CoordinatesZ, true); 
        }

        public async Task<AvatarLocationModel> DeleteAvatarLocation(int IdAvatarLocation, bool Active)
        {
            AvatarLocationModel AvatarLocationToDelete = await _avatarLocationRepository.GetavatarLocation(IdAvatarLocation);

            if (AvatarLocationToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                AvatarLocationToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _avatarLocationRepository.UpdateavatarLocation(AvatarLocationToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("AvatarLocation not found.");
            }
        }

        public async Task<AvatarLocationModel> UpdateAvatarLocation(int AvatarLocationId, int? GameId, int? DetectiveId, decimal? CoordinatesX, decimal? CoordinatesY, decimal? CoordinatesZ)
        {
            AvatarLocationModel newAvatarLocation= await _avatarLocationRepository.GetavatarLocation(AvatarLocationId);
            if (newAvatarLocation != null)
            {
                if (newAvatarLocation != null)
                {
                    // newAvatarLocation.AvatarLocationId = AvatarLocationId;
                    newAvatarLocation.GameId = (int)GameId;
                    newAvatarLocation.DetectiveId = (int)DetectiveId;
                    newAvatarLocation.CoordinatesX = CoordinatesX;
                    newAvatarLocation.CoordinatesY = CoordinatesY;
                    newAvatarLocation.CoordinatesZ = CoordinatesZ;

                }
                return await _avatarLocationRepository.UpdateavatarLocation(newAvatarLocation);
            }
            throw new NotImplementedException();
        }
    }
}
