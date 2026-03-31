using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    // Repositorio que guarda y recupera alimentos desde un archivo JSON
    public class FoodJsonRepository : IFoodRepository
    {
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "foods.json");

        public FoodJsonRepository()
        {
            EnsureFoodFileExists();
        }

        public void Add(Food food)
        {
            List<Food> foods = GetAll();

            food.Id = foods.Count == 0 ? 1 : foods.Max(f => f.Id) + 1;
            foods.Add(food);

            SaveAll(foods);
        }

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

        public void Delete(int foodId)
        {
            List<Food> foods = GetAll();

            Food foodToRemove = foods.FirstOrDefault(f => f.Id == foodId);

            if (foodToRemove != null)
            {
                foods.Remove(foodToRemove);
                SaveAll(foods);
            }
        }

        public void Update(Food food)
        {
            List<Food> foods = GetAll();

            Food existingFood = foods.FirstOrDefault(f => f.Id == food.Id);

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

        private void SaveAll(List<Food> foods)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

            string json = JsonSerializer.Serialize(foods, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        private void EnsureFoodFileExists()
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