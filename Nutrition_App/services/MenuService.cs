using System.Linq;
using Nutrition_App.Models;
using Nutrition_App.Repositories;

namespace Nutrition_App.Services
{
    /// <summary>
    /// Servicio encargado de obtener el menú correspondiente a un usuario
    /// según su objetivo y tipo de dieta.
    /// </summary>
    public class MenuService
    {
        private readonly MenuJsonRepository _menuRepository;

        /// <summary>
        /// Inicializa el servicio de menús utilizando el repositorio JSON.
        /// </summary>
        public MenuService()
        {
            _menuRepository = new MenuJsonRepository();
        }

        /// <summary>
        /// Obtiene el menú asignado a un usuario basado en su objetivo y tipo de dieta.
        /// Aplica normalización para evitar problemas por diferencias de texto.
        /// </summary>
        /// <param name="user">Usuario al que se le desea asignar un menú.</param>
        /// <returns>Menú correspondiente o null si no existe coincidencia.</returns>
        public Menu? GetMenuForUser(User user)
        {
            var menus = _menuRepository.GetAllMenus();

            string userGoal = NormalizeGoal(user.Goal);
            string userDietType = NormalizeDietType(user.DietType);

            return menus.FirstOrDefault(m =>
                NormalizeGoal(m.Goal) == userGoal &&
                NormalizeDietType(m.DietType) == userDietType);
        }

        /// <summary>
        /// Normaliza el objetivo del usuario para asegurar consistencia
        /// entre diferentes formas de escritura (inglés/español).
        /// </summary>
        private static string NormalizeGoal(string goal)
        {
            string value = NormalizeText(goal);

            switch (value)
            {
                case "maintain":
                case "mantener":
                case "mantener peso":
                case "maintain weight":
                    return "maintain";

                case "losefat":
                case "lose fat":
                case "perder grasa":
                case "perdergrasa":
                case "perder peso":
                case "bajar grasa":
                case "lose weight":
                    return "losefat";

                case "gainmuscle":
                case "gain muscle":
                case "ganar masa":
                case "ganar masa muscular":
                case "ganarmasa":
                case "ganar peso":
                case "aumentar peso":
                case "aumentar de peso":
                case "gain weight":
                    return "gainmuscle";

                default:
                    return value;
            }
        }

        /// <summary>
        /// Normaliza el tipo de dieta para asegurar coincidencias correctas
        /// independientemente del idioma o variaciones de escritura.
        /// </summary>
        private static string NormalizeDietType(string dietType)
        {
            string value = NormalizeText(dietType);

            switch (value)
            {
                case "standard":
                case "estandar":
                case "estándar":
                case "estadanr":
                    return "standard";

                case "keto":
                    return "keto";

                case "vegetarian":
                case "vegetariano":
                case "vegetariana":
                    return "vegetarian";

                default:
                    return value;
            }
        }

        /// <summary>
        /// Limpia y normaliza un texto eliminando espacios, convirtiéndolo a minúsculas
        /// y reemplazando caracteres con tilde para evitar inconsistencias.
        /// </summary>
        private static string NormalizeText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            return text.Trim().ToLower()
                .Replace("á", "a")
                .Replace("é", "e")
                .Replace("í", "i")
                .Replace("ó", "o")
                .Replace("ú", "u");
        }
    }
}