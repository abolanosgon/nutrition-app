using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    // Repository que gestiona la persistencia de registros de comidas en un archivo JSON
    public class MealRecordJsonRepository : IMealRecordRepository
    {
        private readonly string filePath;

        public MealRecordJsonRepository()
        {
            // Construye la ruta hacia /data/mealRecords.json desde el directorio del ejecutable
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName ?? baseDir;

            filePath = Path.Combine(projectDir, "data", "mealRecords.json");

            // Asegura que el archivo exista antes de usarlo
            EnsureFileExists();
        }

        // Agrega un nuevo registro de comida con Id incremental
        public void Add(MealRecord record)
        {
            List<MealRecord> records = GetAll();

            record.Id = records.Count == 0 ? 1 : records.Max(r => r.Id) + 1;
            records.Add(record);

            SaveAll(records);
        }

        // Obtiene todos los registros desde el archivo JSON
        public List<MealRecord> GetAll()
        {
            EnsureFileExists();

            string json = File.ReadAllText(filePath);

            // Si el archivo está vacío, retorna lista vacía
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<MealRecord>();
            }

            return JsonSerializer.Deserialize<List<MealRecord>>(json) ?? new List<MealRecord>();
        }

        // Elimina un registro por su Id
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

        // Actualiza los datos de un registro existente
        public void Update(MealRecord record)
        {
            List<MealRecord> records = GetAll();

            MealRecord? existingRecord = records.FirstOrDefault(r => r.Id == record.Id);

            if (existingRecord != null)
            {
                // Se actualizan las propiedades del registro encontrado
                existingRecord.UserId = record.UserId;
                existingRecord.FoodId = record.FoodId;
                existingRecord.RecordDate = record.RecordDate;
                existingRecord.MealType = record.MealType;
                existingRecord.Quantity = record.Quantity;

                SaveAll(records);
            }
        }

        // Guarda todos los registros sobrescribiendo el archivo JSON
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

        // Crea el archivo si no existe, inicializándolo como lista vacía
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