using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Game_Unity.Services
{
    public interface IWeathercontitionService
    {
        Task<List<WeathercontitionsModel>> GetAll();
        Task<WeathercontitionsModel> GetWeathercontitions(int IdWeathercontitions);
        Task<WeathercontitionsModel> CreateWeathercontitions
            (string TypeWeather, string Description, bool Active);
        Task<WeathercontitionsModel> UpdateWeathercontitions
            (int WeathercontitionsID, string TypeWeather, string Description);
        Task<WeathercontitionsModel> DeleteWeathercontitions(int WeathercontitionsID, bool Active);
    }

    public class WeathercontitionService : IWeathercontitionService
    {

        public readonly IWeathercontitionRepository _weathercontitionRepository;
        public WeathercontitionService(IWeathercontitionRepository weathercontitionRepository)
        {
            _weathercontitionRepository = weathercontitionRepository;
        }

        public async Task<List<WeathercontitionsModel>> GetAll()
        {
            return await _weathercontitionRepository.GetAll();
        }

        public async Task<WeathercontitionsModel> GetWeathercontitions(int IdWeathercontitions)
        {
            return await _weathercontitionRepository.GetWeathercontitions(IdWeathercontitions);
        }

        public async Task<WeathercontitionsModel> CreateWeathercontitions(string TypeWeather, string Description, bool Active)
        {
            return await _weathercontitionRepository.CreateWeathercontitions(TypeWeather, Description, Active);
        }

        public async Task<WeathercontitionsModel> DeleteWeathercontitions(int WeathercontitionsID, bool Active)
        {
            WeathercontitionsModel WeathercontitionToDelete = await _weathercontitionRepository.GetWeathercontitions(WeathercontitionsID);

            if (WeathercontitionToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                WeathercontitionToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _weathercontitionRepository.UpdateWeathercontition(WeathercontitionToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("Weathercontitions not found.");
            }
        }

        public async Task<WeathercontitionsModel> UpdateWeathercontitions(int WeathercontitionsID, string TypeWeather, string Description)
        {
            WeathercontitionsModel newWeathercontition= await _weathercontitionRepository.GetWeathercontitions(WeathercontitionsID);
            if (newWeathercontition != null)
            {
                if (newWeathercontition != null)
                {
                    newWeathercontition.TypeWeather = TypeWeather;
                    newWeathercontition.Description = Description;
                    newWeathercontition.Active = true;
                }
                return await _weathercontitionRepository.UpdateWeathercontition(newWeathercontition);
            }
            throw new NotImplementedException();
        }
    }
    
}
