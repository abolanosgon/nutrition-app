using System.Collections.Generic;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    // Interfaz que define las operaciones básicas para el manejo de alimentos.
    // Permite desacoplar la lógica del servicio de la implementación concreta (por ejemplo, JSON, base de datos, etc.).
    public interface IFoodRepository
    {
        // Agrega un nuevo alimento
        void Add(Food food);

        // Obtiene todos los alimentos almacenados
        List<Food> GetAll();

        // Elimina un alimento según su Id
        void Delete(int foodId);

        // Actualiza la información de un alimento existente
        void Update(Food food);
    }
}