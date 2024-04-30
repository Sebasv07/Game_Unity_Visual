using System.Numerics;
using Game_Unity.Models;
using Game_Unity.Context;
using Microsoft.EntityFrameworkCore;
namespace Game_Unity.Repository
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAll();
        Task<UserModel> GetUser(int idUser);
        Task<UserModel> CreateUser
            (
             string NameUser
            ,string Password
            ,string EMail
            ,int Level
            ,int Experience
            ,int Score
            ,DateTime RegistrationDate
            ,int Departure,
             bool Active
            );

        Task<UserModel> UpdateUser(UserModel user);
        Task<UserModel> DeleteUser(UserModel user);
    } 


    public class UserRepository:IUserRepository
    {

        private readonly UserContext _db;
        public UserRepository(UserContext db)
        {
            _db = db;
        }
        public async Task<List<UserModel>> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<UserModel> GetUser(int idUser)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserId == idUser);
        }


        public async Task<UserModel> CreateUser(string NameUser, string Password, string EMail, int Level, int Experience, int Score, DateTime RegistrationDate, int Departure, bool Active)
        {
            UserModel newUser = new UserModel
            {
                NameUser = NameUser,
                Password = Password,
                EMail = EMail,  
                Level = Level,
                Experience = Experience,
                Score = Score,
                RegistrationDate = RegistrationDate,
                Departure = Departure,
                Active = Active
            };

            await _db.Users.AddAsync(newUser);
            _db.SaveChangesAsync();
            return newUser;
        }

        public async Task<UserModel> DeleteUser(UserModel user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}
