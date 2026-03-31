using System.Collections.Generic;
using Nutrition_App.Models;
using Nutrition_App.Repositories;

namespace Nutrition_App.Services
{
    // Maneja la lógica relacionada con los registros de consumo
    public class MealRecordService
    {
        private readonly IMealRecordRepository mealRecordRepository;

        public MealRecordService(IMealRecordRepository mealRecordRepository)
        {
            this.mealRecordRepository = mealRecordRepository;
        }

        public void AddRecord(MealRecord record)
        {
            mealRecordRepository.Add(record);
        }

        public List<MealRecord> GetRecords()
        {
            return mealRecordRepository.GetAll();
        }

        public void DeleteRecord(int recordId)
        {
            mealRecordRepository.Delete(recordId);
        }

        public void UpdateRecord(MealRecord record)
        {
            mealRecordRepository.Update(record);
        }
    }
}