using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    // Repositorio encargado de gestionar los registros de comidas en un archivo JSON.
    // Implementa operaciones CRUD sobre mealRecords.json.
    public class MealRecordJsonRepository : IMealRecordRepository
    {
        // Ruta del archivo donde se almacenan los registros
        private readonly string filePath;

        public MealRecordJsonRepository()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName ?? baseDir;

            filePath = Path.Combine(projectDir, "data", "mealRecords.json");

            // Asegura que el archivo exista antes de trabajar con él
            EnsureFileExists();
        }

        // Agrega un nuevo registro de comida
        public void Add(MealRecord record)
        {
            List<MealRecord> records = GetAll();

            // Asigna Id consecutivo
            record.Id = records.Count == 0 ? 1 : records.Max(r => r.Id) + 1;
            records.Add(record);

            SaveAll(records);
        }

        // Obtiene todos los registros de comidas
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

        // Elimina un registro según su Id
        public void Delete(int recordId)
        {
            List<MealRecord> records = GetAll();

            MealRecord? recordToRemove = records.FirstOrDefault(r => r.Id == recordId);

            if (recordToRemove != null)
            {
                records.Remove(recordToRemove);
                SaveAll(records);
            }
        }

        // Actualiza un registro existente
        public void Update(MealRecord record)
        {
            List<MealRecord> records = GetAll();

            MealRecord? existingRecord = records.FirstOrDefault(r => r.Id == record.Id);

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

        // Guarda todos los registros en el archivo JSON
        private void SaveAll(List<MealRecord> records)
        {
            string? directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonSerializer.Serialize(records, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        // Verifica que el archivo exista; si no, lo crea vacío
        private void EnsureFileExists()
        {
            string? directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }
        }
    }
}