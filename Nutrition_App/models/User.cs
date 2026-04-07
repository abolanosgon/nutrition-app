namespace Nutrition_App.Models
{
    // Modelo que representa un usuario del sistema.
    // Contiene información personal, física y de configuración nutricional.
    public class User
    {
        // Identificador único del usuario
        public int Id { get; set; }

        // Nombre completo del usuario
        public string Name { get; set; } = "";

        // Nombre de usuario para iniciar sesión
        public string Username { get; set; } = "";

        // Contraseña del usuario (almacenada en texto plano en esta implementación)
        public string Password { get; set; } = "";

        // Edad del usuario
        public int Age { get; set; }

        // Peso del usuario en kilogramos
        public double Weight { get; set; }

        // Altura del usuario en centímetros
        public double Height { get; set; }

        // Género del usuario (ej: Male, Female)
        public string Gender { get; set; } = "";

        // Objetivo del usuario (Maintain, LoseFat, GainMuscle)
        public string Goal { get; set; } = "";

        // Nivel de actividad física (Sedentary, Light, Moderate, Active)
        public string ActivityLevel { get; set; } = "";

        // Tipo de dieta (Standard, Keto, Vegetarian)
        public string DietType { get; set; } = "";

        // Rol dentro del sistema (Admin o User)
        public string Role { get; set; } = "";
    }
}