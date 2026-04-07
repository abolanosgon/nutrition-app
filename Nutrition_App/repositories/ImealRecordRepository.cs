using System.Collections.Generic;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    // Define las operaciones básicas para la gestión de registros de comidas
    public interface IMealRecordRepository
    {
        // Agrega un nuevo registro de comida
        void Add(MealRecord record);

        // Obtiene todos los registros de comidas
        List<MealRecord> GetAll();

        // Elimina un registro de comida por su Id
        void Delete(int recordId);

        // Actualiza la información de un registro existente
        void Update(MealRecord record);
    }
}