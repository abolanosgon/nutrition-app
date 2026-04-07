using System.Collections.Generic;
using Nutrition_App.Models;
using Nutrition_App.Repositories;

namespace Nutrition_App.Services
{
    // Servicio encargado de manejar la lógica de registros de comidas.
    // Actúa como intermediario entre el controlador y el repositorio.
    public class MealRecordService
    {
        // Repositorio para acceder a los datos de registros de comida
        private readonly IMealRecordRepository mealRecordRepository;

        // Constructor que recibe la implementación del repositorio
        public MealRecordService(IMealRecordRepository mealRecordRepository)
        {
            this.mealRecordRepository = mealRecordRepository;
        }

        // Agrega un nuevo registro de comida
        public void AddRecord(MealRecord record)
        {
            mealRecordRepository.Add(record);
        }

        // Obtiene todos los registros de comida
        public List<MealRecord> GetRecords()
        {
            return mealRecordRepository.GetAll();
        }

        // Elimina un registro de comida según su Id
        public void DeleteRecord(int recordId)
        {
            mealRecordRepository.Delete(recordId);
        }

        // Actualiza un registro de comida existente
        public void UpdateRecord(MealRecord record)
        {
            mealRecordRepository.Update(record);
        }
    }
}