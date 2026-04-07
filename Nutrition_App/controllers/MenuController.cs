using Nutrition_App.Models;
using Nutrition_App.Services;

namespace Nutrition_App.Controllers
{
    // Controlador encargado de gestionar la asignación de menús a los usuarios.
    // Actúa como intermediario entre la vista y el servicio de menús.
    public class MenuController
    {
        // Servicio que contiene la lógica de asignación de menús
        private readonly MenuService _menuService;

        public MenuController()
        {
            _menuService = new MenuService();
        }

        // Obtiene el menú asignado a un usuario según su perfil
        public Menu? GetAssignedMenu(User user)
        {
            // Validación básica
            if (user == null)
                return null;

            // Delega la lógica al servicio
            return _menuService.GetMenuForUser(user);
        }
    }
}