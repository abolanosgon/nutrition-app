using System.Collections.Generic;
using System.Linq;
using Nutrition_App.Models;
using Nutrition_App.Repositories;

namespace Nutrition_App.Services
{
    // Maneja la lógica relacionada con los usuarios
    public class UserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // Agrega un nuevo usuario al sistema
        public void AddUser(User user)
        {
            List<User> users = userRepository.GetAll();

            // Asigna un ID consecutivo automáticamente
            user.Id = users.Count == 0 ? 1 : users.Max(u => u.Id) + 1;

            userRepository.Add(user);
        }

        // Retorna todos los usuarios registrados
        public List<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        public void DeleteUser(int userId)
        {
            userRepository.Delete(userId);
        }

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