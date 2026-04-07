using System.Collections.Generic;

namespace Nutrition_App.Models
{
    // Modelo que representa un menú nutricional.
    // Se utiliza para asignar planes de alimentación según objetivo y tipo de dieta.
    public class Menu
    {
        // Identificador único del menú
        public int Id { get; set; }

        // Nombre del menú (ej: "Plan estándar mantenimiento")
        public string Name { get; set; } = "";

        // Objetivo asociado al menú (Maintain, LoseFat, GainMuscle)
        public string Goal { get; set; } = "";

        // Tipo de dieta del menú (Standard, Keto, Vegetarian)
        public string DietType { get; set; } = "";

        // Lista de elementos que componen el menú (comidas específicas)
        public List<MenuItem> Items { get; set; } = new List<MenuItem>();
    }
}