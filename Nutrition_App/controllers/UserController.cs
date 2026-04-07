using System.Collections.Generic;
using System.Linq;
using Nutrition_App.Models;
using Nutrition_App.Repositories;
using Nutrition_App.Services;

namespace Nutrition_App.Controllers
{
    // Controlador encargado de gestionar las operaciones relacionadas con usuarios.
    // Actúa como intermediario entre la vista y el servicio de usuarios.
    public class UserController
    {
        // Servicio que contiene la lógica de negocio de usuarios
        private readonly UserService userService;

        public UserController()
        {
            // Inicializa el repositorio y el servicio
            IUserRepository userRepository = new UserJsonRepository();
            userService = new UserService(userRepository);
        }

        // Registra un nuevo usuario
        public void RegisterUser(User user)
        {
            userService.AddUser(user);
        }

        // Obtiene la lista completa de usuarios
        public List<User> GetUsers()
        {
            return userService.GetUsers();
        }

        // Elimina un usuario por Id
        public void DeleteUser(int userId)
        {
            userService.DeleteUser(userId);
        }

        // Actualiza un usuario existente
        public void UpdateUser(User user)
        {
            userService.UpdateUser(user);
        }

        // Autentica un usuario verificando username y password
        public User? AuthenticateUser(string username, string password)
        {
            List<User> users = userService.GetUsers();
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        // Verifica que exista un usuario administrador, si no lo crea
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