using System.Collections.Generic;
using System.Linq;
using Nutrition_App.Models;
using Nutrition_App.Repositories;
using Nutrition_App.Services;

namespace Nutrition_App.Controllers
{
    // Controlador encargado de gestionar los registros de comidas.
    // Conecta la vista con la lógica de negocio (service).
    public class MealRecordController
    {
        // Servicio que maneja la lógica de registros de comidas
        private readonly MealRecordService mealRecordService;

        public MealRecordController()
        {
            // Inicializa el repositorio y el servicio
            IMealRecordRepository mealRecordRepository = new MealRecordJsonRepository();
            mealRecordService = new MealRecordService(mealRecordRepository);
        }

        // Registra un nuevo registro de comida
        public void RegisterRecord(MealRecord record)
        {
            mealRecordService.AddRecord(record);
        }

        // Obtiene todos los registros de comidas
        public List<MealRecord> GetRecords()
        {
            return mealRecordService.GetRecords();
        }

        // Elimina un registro por Id
        public void DeleteRecord(int recordId)
        {
            mealRecordService.DeleteRecord(recordId);
        }

        // Actualiza un registro existente
        public void UpdateRecord(MealRecord record)
        {
            mealRecordService.UpdateRecord(record);
        }

        // Obtiene un registro específico por su Id
        public MealRecord? GetRecordById(int recordId)
        {
            List<MealRecord> records = mealRecordService.GetRecords();
            return records.FirstOrDefault(r => r.Id == recordId);
        }
    }
}