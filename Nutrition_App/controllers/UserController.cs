using System.Collections.Generic;
using System.Linq;
using Nutrition_App.Models;
using Nutrition_App.Repositories;
using Nutrition_App.Services;

namespace Nutrition_App.Controllers
{
    // Controlador encargado de gestionar las operaciones relacionadas con usuarios
    public class UserController
    {
        private readonly UserService userService;

        public UserController()
        {
            // Inicializa el servicio utilizando el repositorio de usuarios en JSON
            IUserRepository userRepository = new UserJsonRepository();
            userService = new UserService(userRepository);
        }

        // Registra un nuevo usuario
        public void RegisterUser(User user)
        {
            userService.AddUser(user);
        }

        // Obtiene la lista de todos los usuarios
        public List<User> GetUsers()
        {
            return userService.GetUsers();
        }

        // Elimina un usuario por su Id
        public void DeleteUser(int userId)
        {
            userService.DeleteUser(userId);
        }

        // Actualiza la información de un usuario
        public void UpdateUser(User user)
        {
            userService.UpdateUser(user);
        }

        // Autentica un usuario según username y password
        public User? AuthenticateUser(string username, string password)
        {
            List<User> users = userService.GetUsers();
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        // Garantiza que exista un usuario administrador en el sistema
        public void EnsureAdminUser()
        {
            userService.EnsureAdminUser();
        }

        // Obtiene un usuario específico por su Id
        public User? GetUserById(int userId)
        {
            List<User> users = userService.GetUsers();
            return users.FirstOrDefault(u => u.Id == userId);
        }
    }
}