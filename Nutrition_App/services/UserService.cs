using System.Collections.Generic;
using System.Linq;
using Nutrition_App.Models;
using Nutrition_App.Repositories;

namespace Nutrition_App.Services
{
    /// <summary>
    /// Servicio encargado de gestionar las operaciones relacionadas con los usuarios.
    /// Actúa como intermediario entre los controladores y el repositorio de usuarios.
    /// </summary>
    public class UserService
    {
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Inicializa una nueva instancia del servicio de usuarios.
        /// </summary>
        /// <param name="userRepository">Repositorio utilizado para acceder a los datos de usuarios.</param>
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Agrega un nuevo usuario al sistema asignándole un identificador único.
        /// </summary>
        /// <param name="user">Usuario que se desea registrar.</param>
        public void AddUser(User user)
        {
            List<User> users = userRepository.GetAll();

            user.Id = users.Count == 0 ? 1 : users.Max(u => u.Id) + 1;

            userRepository.Add(user);
        }

        /// <summary>
        /// Obtiene la lista completa de usuarios registrados.
        /// </summary>
        /// <returns>Lista de usuarios disponibles en el sistema.</returns>
        public List<User> GetUsers()
        {
            return userRepository.GetAll();
        }

        /// <summary>
        /// Elimina un usuario del sistema según su identificador.
        /// </summary>
        /// <param name="userId">Identificador del usuario a eliminar.</param>
        public void DeleteUser(int userId)
        {
            userRepository.Delete(userId);
        }

        /// <summary>
        /// Actualiza la información de un usuario existente.
        /// </summary>
        /// <param name="user">Usuario con los datos actualizados.</param>
        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }

#pragma warning disable S2068
        /// <summary>
        /// Verifica si existe al menos un usuario administrador en el sistema.
        /// Si no existe, crea automáticamente uno con valores predeterminados.
        /// </summary>
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