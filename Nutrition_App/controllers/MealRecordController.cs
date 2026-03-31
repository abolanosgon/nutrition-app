using System.Collections.Generic;
using System.Linq;
using Nutrition_App.Models;
using Nutrition_App.Repositories;
using Nutrition_App.Services;

namespace Nutrition_App.Controllers
{
    // Coordina la comunicación entre la vista y la lógica de registros de consumo
    public class MealRecordController
    {
        private readonly MealRecordService mealRecordService;

        public MealRecordController()
        {
            IMealRecordRepository mealRecordRepository = new MealRecordJsonRepository();
            mealRecordService = new MealRecordService(mealRecordRepository);
        }

        public void RegisterRecord(MealRecord record)
        {
            mealRecordService.AddRecord(record);
        }

        public List<MealRecord> GetRecords()
        {
            return mealRecordService.GetRecords();
        }

        public void DeleteRecord(int recordId)
        {
            mealRecordService.DeleteRecord(recordId);
        }

        public void UpdateRecord(MealRecord record)
        {
            mealRecordService.UpdateRecord(record);
        }

        public MealRecord GetRecordById(int recordId)
        {
            List<MealRecord> records = mealRecordService.GetRecords();
            return records.FirstOrDefault(r => r.Id == recordId);
        }
    }
}