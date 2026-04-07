using System.Collections.Generic;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    // Interfaz que define las operaciones básicas para el manejo de usuarios.
    // Permite separar la lógica del sistema de la forma en que se almacenan los datos.
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