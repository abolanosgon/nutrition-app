namespace Nutrition_App.Models
{
    // Representa un registro de comida realizado por un usuario
    public class MealRecord
    {
        // Identificador único del registro
        public int Id { get; set; }

        // Id del usuario que realizó el registro
        public int UserId { get; set; }

        // Id del alimento consumido
        public int FoodId { get; set; }

        // Fecha en la que se registró la comida
        public DateTime RecordDate { get; set; }

        // Tipo de comida (ej: desayuno, almuerzo, cena)
        public string MealType { get; set; } = "";

        // Cantidad consumida del alimento
        public double Quantity { get; set; }
    }
}