using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    public class MealRecordJsonRepository : IMealRecordRepository
    {
        private readonly string filePath = Path.Combine(
            Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName,
            "data",
            "mealRecords.json"
        );

        public MealRecordJsonRepository()
        {
            EnsureFileExists();
        }

        public void Add(MealRecord record)
        {
            List<MealRecord> records = GetAll();

            record.Id = records.Count == 0 ? 1 : records.Max(r => r.Id) + 1;
            records.Add(record);

            SaveAll(records);
        }

        public List<MealRecord> GetAll()
        {
            EnsureFileExists();

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<MealRecord>();
            }

            return JsonSerializer.Deserialize<List<MealRecord>>(json) ?? new List<MealRecord>();
        }

        public void Delete(int recordId)
        {
            List<MealRecord> records = GetAll();

            MealRecord recordToRemove = records.FirstOrDefault(r => r.Id == recordId);

            if (recordToRemove != null)
            {
                records.Remove(recordToRemove);
                SaveAll(records);
            }
        }

        public void Update(MealRecord record)
        {
            List<MealRecord> records = GetAll();

            MealRecord existingRecord = records.FirstOrDefault(r => r.Id == record.Id);

            if (existingRecord != null)
            {
                existingRecord.UserId = record.UserId;
                existingRecord.FoodId = record.FoodId;
                existingRecord.RecordDate = record.RecordDate;
                existingRecord.MealType = record.MealType;
                existingRecord.Quantity = record.Quantity;

                SaveAll(records);
            }
        }

        private void SaveAll(List<MealRecord> records)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

            string json = JsonSerializer.Serialize(records, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        private void EnsureFileExists()
        {
            string directory = Path.GetDirectoryName(filePath)!;
            Directory.CreateDirectory(directory);

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }
        }
    }
}