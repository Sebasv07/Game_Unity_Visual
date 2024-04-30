using Game_Unity.Context;
using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Repository
{
    public interface IPlagueRepository
    {
        Task<List<PlagueModel>> GetAll();
        Task<PlagueModel> GetPlague(int idPlague);
        Task<PlagueModel> CreatePlague
            (string NamePlague, string Description, bool Active);

        Task<PlagueModel> UpdatePlague(PlagueModel plague);
        Task<PlagueModel> DeletePlague(PlagueModel plague);

    }
    public class PlagueRepository : IPlagueRepository
    {
        private readonly PlagueContext _db;
        public PlagueRepository(PlagueContext db)
        {
            _db = db;
        }

        public async Task<List<PlagueModel>> GetAll()
        {
            return await _db.Plagues.ToListAsync();
        }

        public async Task<PlagueModel> GetPlague(int idPlague)
        {
            return await _db.Plagues.FirstOrDefaultAsync(u => u.PlagueId== idPlague);
        }

        public async Task<PlagueModel> CreatePlague(string NamePlague, string Description, bool Active)
        {
            PlagueModel newPlague = new PlagueModel
            {
             NamePlague = NamePlague,
             Description = Description,
             Active = Active
            };

            await _db.Plagues.AddAsync(newPlague);
            _db.SaveChangesAsync();
            return newPlague;
        }

        public async Task<PlagueModel> DeletePlague(PlagueModel plague)
        {
            _db.Plagues.Update(plague);
            await _db.SaveChangesAsync();
            return plague;
        }

        public async Task<PlagueModel> UpdatePlague(PlagueModel plague)
        {
            _db.Plagues.Update(plague);
            await _db.SaveChangesAsync();
            return plague;
        }
    }
}
