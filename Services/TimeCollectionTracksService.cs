using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;

namespace Game_Unity.Services
{
    public interface ITimeCollectionTrackService
    {
        Task<List<TimeCollectionTracksModel>> GetAll();
        Task<TimeCollectionTracksModel> GetTimeCollectionTrack(int IdtimeCollectionTrack);
        Task<TimeCollectionTracksModel> CreateTimeCollectionTrack
            (int DetectiveId, int GameId, int DetectiveCluesId, DateTime TimeClues, bool Active);
        Task<TimeCollectionTracksModel> UpdateTimeCollectionTrack
            (int TimeCollectionTracksId, int ? DetectiveId, int ? GameId, int? DetectiveCluesId, DateTime? TimeClues, bool Active);
        Task<TimeCollectionTracksModel> DeleteGetTimeCollectionTrack(int IdtimeCollectionTrack, bool Active);

    }

    public class TimeCollectionTracksService: ITimeCollectionTrackService
    {
        public readonly ITimeCollectionTracksRepository _timecollectiontracksrepository;

        public TimeCollectionTracksService(ITimeCollectionTracksRepository timeCollectionTracksRepository)
        {
            _timecollectiontracksrepository = timeCollectionTracksRepository;
        }

        public async Task<List<TimeCollectionTracksModel>> GetAll()
        {
            return await _timecollectiontracksrepository.GetAll();
        }

        public async Task<TimeCollectionTracksModel> GetTimeCollectionTrack(int IdtimeCollectionTrack)
        {
            return await _timecollectiontracksrepository.GetTimeCollectionTracksModel(IdtimeCollectionTrack);
        }

        public async Task<TimeCollectionTracksModel> CreateTimeCollectionTrack(int DetectiveId, int GameId, int DetectiveCluesId, DateTime TimeClues, bool Active)
        {
            return await _timecollectiontracksrepository.CreateTimeCollectionTracksModel(DetectiveId,GameId, DetectiveCluesId, TimeClues, true);
        }

        public async Task<TimeCollectionTracksModel> DeleteGetTimeCollectionTrack(int IdtimeCollectionTrack, bool Active)
        {
            TimeCollectionTracksModel GetTimeCollectionTrackToDelete = await _timecollectiontracksrepository.GetTimeCollectionTracksModel(IdtimeCollectionTrack);

            if (GetTimeCollectionTrackToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                GetTimeCollectionTrackToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _timecollectiontracksrepository.UpdateTimeCollectionTracksModel(GetTimeCollectionTrackToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("TimeCollectionTrack not found.");
            }
        }

        public async Task<TimeCollectionTracksModel> UpdateTimeCollectionTrack(int TimeCollectionTracksId, int? DetectiveId, int? GameId, int? DetectiveCluesId, DateTime? TimeClues, bool Active)
        {
            TimeCollectionTracksModel newTimeCollectionTracks = await _timecollectiontracksrepository.GetTimeCollectionTracksModel(TimeCollectionTracksId);
            if (newTimeCollectionTracks != null)
            {
                if (newTimeCollectionTracks != null)
                {
                //    newTimeCollectionTracks.TimeCollectionTracksId = TimeCollectionTracksId;
                    newTimeCollectionTracks.DetectiveId = (int)DetectiveId;
                    newTimeCollectionTracks.GameId = (int)GameId;
                    newTimeCollectionTracks.DetectiveCluesId = (int)DetectiveCluesId;
                    newTimeCollectionTracks.TimeClues = TimeClues;
                    newTimeCollectionTracks.Active = Active;
                }
                return await _timecollectiontracksrepository.UpdateTimeCollectionTracksModel(newTimeCollectionTracks);
            }
            throw new NotImplementedException();
        }
    }
}
