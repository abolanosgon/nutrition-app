using Nutrition_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Nutrition_App.Repositories
{
    public class MenuJsonRepository
    {
        private readonly string _filePath;

        public MenuJsonRepository()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName ?? baseDir;

            _filePath = Path.Combine(projectDir, "data", "menus.json");

            EnsureMenuFileExists();
        }

        public List<Menu> GetAllMenus()
        {
            EnsureMenuFileExists();

            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Menu>();
            }

            return JsonSerializer.Deserialize<List<Menu>>(json) ?? new List<Menu>();
        }

        private void EnsureMenuFileExists()
        {
            string? directory = Path.GetDirectoryName(_filePath);

            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }
    }
}