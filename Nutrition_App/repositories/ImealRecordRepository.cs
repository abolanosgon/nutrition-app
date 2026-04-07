using System.Collections.Generic;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    // Interfaz que define las operaciones básicas para el manejo de registros de comidas.
    // Permite desacoplar la lógica del sistema de la forma en que se almacenan los datos.
    public interface IMealRecordRepository
    {
        // Agrega un nuevo registro de comida
        void Add(MealRecord record);

        // Obtiene todos los registros de comidas
        List<MealRecord> GetAll();

        // Elimina un registro de comida según su Id
        void Delete(int recordId);

        // Actualiza un registro de comida existente
        void Update(MealRecord record);
    }
}