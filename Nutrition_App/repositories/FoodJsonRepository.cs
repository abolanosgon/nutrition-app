using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    // Repository que gestiona la persistencia de alimentos en un archivo JSON
    public class FoodJsonRepository : IFoodRepository
    {
        private readonly string filePath;

        public FoodJsonRepository()
        {
            // Se construye la ruta absoluta hacia /data/foods.json desde el directorio del ejecutable
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName ?? baseDir;

            filePath = Path.Combine(projectDir, "data", "foods.json");

            // Garantiza que el archivo exista antes de cualquier operación
            EnsureFoodFileExists();
        }

        // Agrega un nuevo alimento asignando un Id incremental manualmente
        public void Add(Food food)
        {
            List<Food> foods = GetAll();

            // Generación simple de Id (puede fallar en escenarios concurrentes)
            food.Id = foods.Count == 0 ? 1 : foods.Max(f => f.Id) + 1;
            foods.Add(food);

            SaveAll(foods);
        }

        // Obtiene todos los alimentos desde el archivo JSON
        public List<Food> GetAll()
        {
            EnsureFoodFileExists();

            string json = File.ReadAllText(filePath);

            // Si el archivo está vacío, retorna lista vacía para evitar errores de deserialización
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Food>();
            }

            return JsonSerializer.Deserialize<List<Food>>(json) ?? new List<Food>();
        }

        // Elimina un alimento por Id
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

        // Actualiza los datos de un alimento existente
        public void Update(Food food)
        {
            List<Food> foods = GetAll();

            Food? existingFood = foods.FirstOrDefault(f => f.Id == food.Id);

            if (existingFood != null)
            {
                // Se actualizan manualmente las propiedades para evitar reemplazar la referencia completa
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

        // Sobrescribe completamente el archivo JSON con la lista actual
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

        // Crea el archivo JSON si no existe (inicializado como lista vacía)
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