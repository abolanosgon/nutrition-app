using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    // Repositorio encargado de gestionar el almacenamiento de alimentos en un archivo JSON.
    // Implementa operaciones CRUD básicas sobre foods.json.
    public class FoodJsonRepository : IFoodRepository
    {
        // Ruta del archivo JSON donde se guardan los alimentos
        private readonly string filePath;

        public FoodJsonRepository()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName ?? baseDir;

            filePath = Path.Combine(projectDir, "data", "foods.json");

            // Asegura que el archivo exista antes de usarlo
            EnsureFoodFileExists();
        }

        // Agrega un nuevo alimento al archivo
        public void Add(Food food)
        {
            List<Food> foods = GetAll();

            // Asigna Id consecutivo
            food.Id = foods.Count == 0 ? 1 : foods.Max(f => f.Id) + 1;
            foods.Add(food);

            SaveAll(foods);
        }

        // Obtiene todos los alimentos almacenados
        public List<Food> GetAll()
        {
            EnsureFoodFileExists();

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Food>();
            }

            return JsonSerializer.Deserialize<List<Food>>(json) ?? new List<Food>();
        }

        // Elimina un alimento según su Id
        public void Delete(int foodId)
        {
            List<Food> foods = GetAll();

            Food? foodToRemove = foods.FirstOrDefault(f => f.Id == foodId);

            if (foodToRemove != null)
            {
                foods.Remove(foodToRemove);
                SaveAll(foods);
            }
        }

        // Actualiza un alimento existente según su Id
        public void Update(Food food)
        {
            List<Food> foods = GetAll();

            Food? existingFood = foods.FirstOrDefault(f => f.Id == food.Id);

            if (existingFood != null)
            {
                existingFood.Name = food.Name;
                existingFood.Category = food.Category;
                existingFood.Calories = food.Calories;
                existingFood.Protein = food.Protein;
                existingFood.Carbohydrates = food.Carbohydrates;
                existingFood.Fat = food.Fat;
                existingFood.PortionSize = food.PortionSize;

                SaveAll(foods);
            }
        }

        // Guarda toda la lista de alimentos en el archivo JSON
        private void SaveAll(List<Food> foods)
        {
            string? directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonSerializer.Serialize(foods, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        // Verifica que el archivo foods.json exista
        // Si no existe, lo crea con una lista vacía
        private void EnsureFoodFileExists()
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