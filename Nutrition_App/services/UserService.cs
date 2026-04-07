using System.Collections.Generic;
using System.Linq;
using Nutrition_App.Models;
using Nutrition_App.Repositories;

namespace Nutrition_App.Services
{
    // Servicio encargado de la lógica básica de usuarios.
    // Actúa como intermediario entre el controlador y el repositorio.
    public class UserService
    {
        // Repositorio utilizado para acceder a los datos de usuarios
        private readonly IUserRepository userRepository;

        // Constructor que recibe la implementación del repositorio
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // Agrega un nuevo usuario
        // Antes de guardar, asigna un Id consecutivo
        public void AddUser(User user)
        {
            List<User> users = userRepository.GetAll();

            user.Id = users.Count == 0 ? 1 : users.Max(u => u.Id) + 1;

            userRepository.Add(user);
        }

        // Obtiene la lista completa de usuarios
        public List<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        // Elimina un usuario según su Id
        public void DeleteUser(int userId)
        {
            userRepository.Delete(userId);
        }

        // Actualiza la información de un usuario existente
        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }

        // Verifica si existe al menos un usuario administrador
        // Si no existe, crea uno por defecto
        public void EnsureAdminUser()
        {
            List<User> users = userRepository.GetAll();

            bool adminExists = users.Any(u => u.Role == "Admin");

            if (!adminExists)
            {
                User adminUser = new User
                {
                    Id = users.Count == 0 ? 1 : users.Max(u => u.Id) + 1,
                    Name = "Administrador",
                    Username = "admin",
                    Password = "admin123",
                    Age = 30,
                    Weight = 70,
                    Height = 170,
                    Gender = "Male",
                    Goal = "Maintain",
                    ActivityLevel = "Moderate",
                    DietType = "Standard",
                    Role = "Admin"
                };

                userRepository.Add(adminUser);
            }
        }
    }
}