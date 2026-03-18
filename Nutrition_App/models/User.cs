namespace Nutrition_App.Models
{
    // Representa al usuario que utiliza la aplicación
    public class User
    {
        public int Id { get; set; }               // Identificador único interno
        public string Name { get; set; }          // Nombre del usuario
        public string Username { get; set; }      // Nombre de usuario para iniciar sesión
        public string Password { get; set; }      // Contraseña del usuario
        public int Age { get; set; }              // Edad
        public double Weight { get; set; }        // Peso en kg
        public double Height { get; set; }        // Altura en cm
        public string Gender { get; set; }        // Género
        public string Goal { get; set; }          // Objetivo nutricional
        public string ActivityLevel { get; set; } // Nivel de actividad
        public string DietType { get; set; }      // Tipo de dieta
    }
}