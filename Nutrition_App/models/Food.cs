namespace Nutrition_App.Models
{
    // Modelo que representa un alimento dentro del sistema.
    // Contiene información nutricional y de clasificación.
    public class Food
    {
        // Identificador único del alimento
        public int Id { get; set; }

        // Nombre del alimento
        public string Name { get; set; } = "";

        // Categoría del alimento (ej: Proteína, Carbohidrato, Fruta, etc.)
        public string Category { get; set; } = "";

        // Cantidad de calorías por porción
        public double Calories { get; set; }

        // Cantidad de proteína por porción (gramos)
        public double Protein { get; set; }

        // Cantidad de carbohidratos por porción (gramos)
        public double Carbohydrates { get; set; }

        // Cantidad de grasa por porción (gramos)
        public double Fat { get; set; }

        // Tamaño de la porción (ej: "100g", "1 taza", etc.)
        public string PortionSize { get; set; } = "";
    }
}