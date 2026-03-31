using System.Collections.Generic;
using System.Linq;
using Nutrition_App.Models;
using Nutrition_App.Repositories;
using Nutrition_App.Services;

namespace Nutrition_App.Controllers
{
    // Coordina la comunicación entre la vista y la lógica de usuarios
    public class UserController
    {
        private readonly UserService userService;

        public UserController()
        {
            IUserRepository userRepository = new UserJsonRepository();
            userService = new UserService(userRepository);
        }

        public void RegisterUser(User user)
        {
            userService.AddUser(user);
        }

        public List<User> GetUsers()
        {
            return userService.GetUsers();
        }

        public void DeleteUser(int userId)
        {
            userService.DeleteUser(userId);
        }

        public void UpdateUser(User user)
        {
            userService.UpdateUser(user);
        }

        public User AuthenticateUser(string username, string password)
        {
            List<User> users = userService.GetUsers();
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public void EnsureAdminUser()
        {
            userService.EnsureAdminUser();
        }

        public User GetUserById(int userId)
        {
            List<User> users = userService.GetUsers();
            return users.FirstOrDefault(u => u.Id == userId);
        }
    }
}