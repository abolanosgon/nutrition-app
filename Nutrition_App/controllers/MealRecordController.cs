using System.Collections.Generic;
using System.Linq;
using Nutrition_App.Models;
using Nutrition_App.Repositories;
using Nutrition_App.Services;

namespace Nutrition_App.Controllers
{
    // Controlador encargado de gestionar las operaciones relacionadas con registros de comidas
    public class MealRecordController
    {
        private readonly MealRecordService mealRecordService;

        public MealRecordController()
        {
            // Inicializa el servicio utilizando el repositorio de registros en JSON
            IMealRecordRepository mealRecordRepository = new MealRecordJsonRepository();
            mealRecordService = new MealRecordService(mealRecordRepository);
        }

        // Registra un nuevo registro de comida
        public void RegisterRecord(MealRecord record)
        {
            mealRecordService.AddRecord(record);
        }

        // Obtiene la lista de todos los registros de comidas
        public List<MealRecord> GetRecords()
        {
            return mealRecordService.GetRecords();
        }

        // Elimina un registro de comida por su Id
        public void DeleteRecord(int recordId)
        {
            mealRecordService.DeleteRecord(recordId);
        }

        // Actualiza la información de un registro de comida
        public void UpdateRecord(MealRecord record)
        {
            mealRecordService.UpdateRecord(record);
        }

        // Obtiene un registro de comida específico por su Id
        public MealRecord? GetRecordById(int recordId)
        {
            List<MealRecord> records = mealRecordService.GetRecords();
            return records.FirstOrDefault(r => r.Id == recordId);
        }
    }
}