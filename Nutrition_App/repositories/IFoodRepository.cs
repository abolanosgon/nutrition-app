using System.Collections.Generic;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    // Define las operaciones básicas para la gestión de alimentos
    public interface IFoodRepository
    {
        // Agrega un nuevo alimento
        void Add(Food food);

        // Obtiene la lista completa de alimentos
        List<Food> GetAll();

        // Elimina un alimento según su Id
        void Delete(int foodId);

        // Actualiza la información de un alimento existente
        void Update(Food food);
    }
}