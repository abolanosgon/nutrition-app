namespace Nutrition_App.Models
{
    // Modelo que representa un registro de comida realizado por un usuario.
    // Relaciona usuario, alimento, fecha y cantidad consumida.
    public class MealRecord
    {
        // Identificador único del registro
        public int Id { get; set; }

        // Id del usuario que realizó el registro
        public int UserId { get; set; }

        // Id del alimento consumido
        public int FoodId { get; set; }

        // Fecha y hora en que se registró la comida
        public DateTime RecordDate { get; set; }

        // Tipo de comida (ej: Breakfast, Lunch, Dinner, Snack)
        public string MealType { get; set; } = "";

        // Cantidad consumida del alimento
        public double Quantity { get; set; }
    }
}