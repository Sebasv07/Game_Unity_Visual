using Game_Unity.Models;
using Game_Unity.Repository;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net;
using System.Numerics;

namespace Game_Unity.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAll();
        Task<UserModel> GetUser(int IdUser);
        Task<UserModel> CreateUser
            (string NameUser ,string Password ,string EMail,int Level ,int Experience,int Score, DateTime RegistrationDate, int Departure, bool Active);
        Task<UserModel> UpdateUser
            (int IdUser, string ? NameUser, string? Password, string? EMail, int? Level, int? Experience, int? Score, DateTime? RegistrationDate, int? Departure, bool ? Active);
        Task<UserModel> DeleteUser(int IdUser, bool Active);
     }

    public class UserService: IUserService
    {
        public readonly IUserRepository _userRepository;
        public UserService(IUserRepository userrepository)
        {
            _userRepository = userrepository;
        }

        public async Task<List<UserModel>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<UserModel> GetUser(int IdUser)
        {
            return await _userRepository.GetUser(IdUser);
        }

        public async Task<UserModel> CreateUser(string NameUser, string Password, string EMail, int Level, int Experience, int Score, DateTime RegistrationDate, int Departure, bool Active)
        {
            return await _userRepository.CreateUser(NameUser, Password, EMail, Level, Experience, Score, RegistrationDate, Departure, true);
        }

        public async Task<UserModel> DeleteUser(int IdUser, bool Active)
        {
            UserModel userToDelete = await _userRepository.GetUser(IdUser);

            if (userToDelete != null)
            {
                // Mark the user as inactive or perform any other required logic
                userToDelete.Active = Active;
                Active = false;

                // Save changes to the repository
                return await _userRepository.UpdateUser(userToDelete);
            }
            else
            {
                // User not found, handle accordingly
                throw new Exception("User not found.");
            }
        }
        public async Task<UserModel> UpdateUser(int IdUser, string? NameUser, string? Password, string? EMail, int? Level, int? Experience, int? Score, DateTime? RegistrationDate, int? Departure, bool? Active)
        {
            UserModel newUser = await _userRepository.GetUser(IdUser);
            if (newUser != null)
            {
                if (NameUser != null)
                {
                    newUser.NameUser = NameUser;
                    newUser.Password = Password;
                    newUser.EMail = EMail;
                    newUser.Level = Level;
                    newUser.Experience = Experience;
                    newUser.Score = Score;
                    newUser.Departure = Departure;
                }
                return await _userRepository.UpdateUser(newUser);
            }
            throw new NotImplementedException();
        }
    }
}
