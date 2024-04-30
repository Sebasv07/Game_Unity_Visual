using System.Numerics;
using Game_Unity.Models;
using Game_Unity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Repository
{
    public interface IWeathercontitionRepository
    {
        Task<List<WeathercontitionsModel>> GetAll();
        Task<WeathercontitionsModel> GetWeathercontitions(int idWeathercontitions);
        Task<WeathercontitionsModel> CreateWeathercontitions
            (string TypeWeather, string Description, bool Active);

        Task<WeathercontitionsModel> UpdateWeathercontition(WeathercontitionsModel Weathercontitions);
        Task<WeathercontitionsModel> DeleteWeathercontition(WeathercontitionsModel Weathercontitions);
    }

    public class WeathercontitionRepository:IWeathercontitionRepository
    {
        private readonly WeatherConditionsContext _db;
        public WeathercontitionRepository(WeatherConditionsContext db)
        {
            _db = db;
        }

        public async Task<List<WeathercontitionsModel>> GetAll()
        {
            return await _db.weatherconditions.ToListAsync();
        }

        public async Task<WeathercontitionsModel> GetWeathercontitions(int idWeathercontitions)
        {
            return await _db.weatherconditions.FirstOrDefaultAsync(u => u.WeatherContitionId == idWeathercontitions);
        }
        public async Task<WeathercontitionsModel> CreateWeathercontitions(string TypeWeather, string Description, bool Active)
        {
            WeathercontitionsModel newWeathercontitions = new WeathercontitionsModel
            {
                TypeWeather = TypeWeather, Description = Description, Active = Active       

            };

            await _db.weatherconditions.AddAsync(newWeathercontitions);
            _db.SaveChangesAsync();
            return newWeathercontitions;
        }

        public async Task<WeathercontitionsModel> DeleteWeathercontition(WeathercontitionsModel Weathercontitions)
        {
            _db.weatherconditions.Update(Weathercontitions);
            await _db.SaveChangesAsync();
            return Weathercontitions;
        }

        public async Task<WeathercontitionsModel> UpdateWeathercontition(WeathercontitionsModel Weathercontitions)
        {
            _db.weatherconditions.Update(Weathercontitions);
            await _db.SaveChangesAsync();
            return Weathercontitions;
        }
    }


}
