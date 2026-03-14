namespace Nutrition_App.Models
{
    // Representa al usuario que utiliza la aplicación
    public class User
    {
        public int Id { get; set; }              // Identificador único
        public string Name { get; set; }         // Nombre del usuario
        public int Age { get; set; }             // Edad
        public double Weight { get; set; }       // Peso en kg
        public double Height { get; set; }       // Altura en cm
        public string Gender { get; set; }       // Género
        public string Goal { get; set; }         // Objetivo: mantener, perder grasa, ganar masa
        public string ActivityLevel { get; set; } // Nivel de actividad
        public string DietType { get; set; }     // Tipo de dieta: estándar, keto, vegetariana
    }
}