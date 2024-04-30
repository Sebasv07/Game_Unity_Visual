using Game_Unity.Context;
using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;

namespace Game_Unity.Repository
{
    public interface ITimeCollectionTracksRepository
    {
        Task<List<TimeCollectionTracksModel>> GetAll();
        Task<TimeCollectionTracksModel> GetTimeCollectionTracksModel(int idTimeCollectionTracks);
        Task<TimeCollectionTracksModel> CreateTimeCollectionTracksModel
            (int DetectiveId,int GameId, int DetectiveCluesId, DateTime TimeClues, bool Active);

        Task<TimeCollectionTracksModel> UpdateTimeCollectionTracksModel(TimeCollectionTracksModel timeCollectionTracks);
        Task<TimeCollectionTracksModel> DeleteTimeCollectionTracksModel(TimeCollectionTracksModel timeCollectionTracks);

    }


    public class TimeCollectionTracksRepository: ITimeCollectionTracksRepository
    {
        private readonly TimeCollectionTracksContext _db;

        public TimeCollectionTracksRepository(TimeCollectionTracksContext db)
        {
            _db = db;
        }

        public async Task<List<TimeCollectionTracksModel>> GetAll()
        {
            return await _db.TimeCollectionTracks.ToListAsync();
        }

        public async Task<TimeCollectionTracksModel> GetTimeCollectionTracksModel(int idTimeCollectionTracks)
        {
            return await _db.TimeCollectionTracks.FirstOrDefaultAsync(u => u.TimeCollectionTracksId == idTimeCollectionTracks);
        }

        public async Task<TimeCollectionTracksModel> CreateTimeCollectionTracksModel(int DetectiveId, int GameId, int DetectiveCluesId, DateTime TimeClues, bool Active)
        {
            TimeCollectionTracksModel newTimeCollectionTracks = new TimeCollectionTracksModel
            {
                DetectiveId = DetectiveId,
                GameId = GameId,
                DetectiveCluesId = DetectiveCluesId,
                TimeClues = TimeClues,
                Active = Active
            };

            await _db.TimeCollectionTracks.AddAsync(newTimeCollectionTracks);
            _db.SaveChangesAsync();
            return newTimeCollectionTracks;
        }

        public async Task<TimeCollectionTracksModel> DeleteTimeCollectionTracksModel(TimeCollectionTracksModel timeCollectionTracks)
        {
            _db.TimeCollectionTracks.Update(timeCollectionTracks);
            await _db.SaveChangesAsync();
            return timeCollectionTracks;
        }
        public async Task<TimeCollectionTracksModel> UpdateTimeCollectionTracksModel(TimeCollectionTracksModel timeCollectionTracks)
        {
            _db.TimeCollectionTracks.Update(timeCollectionTracks);
            await _db.SaveChangesAsync();
            return timeCollectionTracks;
        }
    }
}
