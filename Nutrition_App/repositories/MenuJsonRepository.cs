using Nutrition_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Nutrition_App.Repositories
{
    // Repository que gestiona la lectura de menús desde un archivo JSON
    public class MenuJsonRepository
    {
        private readonly string _filePath;

        public MenuJsonRepository()
        {
            // Construye la ruta hacia /data/menus.json desde el directorio del ejecutable
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName ?? baseDir;

            _filePath = Path.Combine(projectDir, "data", "menus.json");

            // Asegura que el archivo exista antes de cualquier lectura
            EnsureMenuFileExists();
        }

        // Obtiene todos los menús almacenados en el archivo JSON
        public List<Menu> GetAllMenus()
        {
            EnsureMenuFileExists();

            string json = File.ReadAllText(_filePath);

            // Si el archivo está vacío, retorna lista vacía
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Menu>();
            }

            return JsonSerializer.Deserialize<List<Menu>>(json) ?? new List<Menu>();
        }

        // Crea el archivo JSON si no existe, inicializándolo como lista vacía
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