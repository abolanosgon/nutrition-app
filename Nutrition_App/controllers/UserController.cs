using System.Collections.Generic;
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

        // Envía el usuario al servicio para registrarlo
        public void RegisterUser(User user)
        {
            userService.AddUser(user);
        }

        public List<User> GetUsers()
        {
            return userService.GetUsers();
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
    }
}