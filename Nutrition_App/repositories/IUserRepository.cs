using System.Collections.Generic;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    // Define las operaciones básicas para la gestión de usuarios
    public interface IUserRepository
    {
        // Obtiene la lista completa de usuarios
        List<User> GetAll();

        // Agrega un nuevo usuario
        void Add(User user);

        // Elimina un usuario según su Id
        void Delete(int userId);

        // Actualiza la información de un usuario existente
        void Update(User user);
    }
}