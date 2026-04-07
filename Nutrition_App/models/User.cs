namespace Nutrition_App.Models
{
    // Representa un usuario dentro del sistema
    public class User
    {
        // Identificador único del usuario
        public int Id { get; set; }

        // Nombre completo del usuario
        public string Name { get; set; } = "";

        // Nombre de usuario para iniciar sesión
        public string Username { get; set; } = "";

        // Contraseña del usuario
        public string Password { get; set; } = "";

        // Edad del usuario
        public int Age { get; set; }

        // Peso del usuario (kg)
        public double Weight { get; set; }

        // Altura del usuario (cm)
        public double Height { get; set; }

        // Género del usuario
        public string Gender { get; set; } = "";

        // Objetivo del usuario (ej: perder peso, ganar masa, etc.)
        public string Goal { get; set; } = "";

        // Nivel de actividad física
        public string ActivityLevel { get; set; } = "";

        // Tipo de dieta preferida
        public string DietType { get; set; } = "";

        // Rol dentro del sistema (ej: admin, user)
        public string Role { get; set; } = "";
    }
}