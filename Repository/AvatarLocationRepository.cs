using Game_Unity.Context;
using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace Game_Unity.Repository
{
    public interface IAvatarLocationRepository
    {
        Task<List<AvatarLocationModel>> GetAll();
        Task<AvatarLocationModel> GetavatarLocation(int idavatarLocation);
        Task<AvatarLocationModel> CreateavatarLocation
        (int GameId, int DetectiveId, decimal CoordinatesX, decimal CoordinatesY, decimal CoordinatesZ, bool Active);
        Task<AvatarLocationModel> UpdateavatarLocation(AvatarLocationModel avatarLocation);
        Task<AvatarLocationModel> DeleteavatarLocation(AvatarLocationModel avatarLocation);
    }

    public class AvatarLocationRepository: IAvatarLocationRepository
    {
        private readonly AvatarLocationContext _db;
        public AvatarLocationRepository(AvatarLocationContext db)
        {
            _db = db;
        }
        public async Task<List<AvatarLocationModel>> GetAll()
        {
            return await _db.AvatarLocations.ToListAsync();
        }

        public async Task<AvatarLocationModel> GetavatarLocation(int idavatarLocation)
        {
            return await _db.AvatarLocations.FirstOrDefaultAsync(u => u.AvatarLocationId == idavatarLocation);
        }

        public async Task<AvatarLocationModel> CreateavatarLocation(int GameId, int DetectiveId, decimal CoordinatesX, decimal CoordinatesY, decimal CoordinatesZ, bool Active)
        {
            AvatarLocationModel newAvatarLocation = new AvatarLocationModel
            {
                GameId = GameId,
                DetectiveId = DetectiveId,
                CoordinatesX = CoordinatesX,
                CoordinatesY = CoordinatesY,
                CoordinatesZ = CoordinatesZ,
                Active = Active
            };

            await _db.AvatarLocations.AddAsync(newAvatarLocation);
            _db.SaveChangesAsync();
            return newAvatarLocation;
        }

        public async Task<AvatarLocationModel> DeleteavatarLocation(AvatarLocationModel avatarLocation)
        {
            _db.AvatarLocations.Update(avatarLocation);
            await _db.SaveChangesAsync();
            return avatarLocation;
        }

        public async Task<AvatarLocationModel> UpdateavatarLocation(AvatarLocationModel avatarLocation)
        {
            _db.AvatarLocations.Update(avatarLocation);
            await _db.SaveChangesAsync();
            return avatarLocation;
        }
    }
}
