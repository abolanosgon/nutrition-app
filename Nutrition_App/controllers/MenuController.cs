using Nutrition_App.Models;
using Nutrition_App.Services;

namespace Nutrition_App.Controllers
{
    // Controlador encargado de gestionar la asignación de menús a usuarios
    public class MenuController
    {
        private readonly MenuService _menuService;

        public MenuController()
        {
            // Inicializa el servicio de menús
            _menuService = new MenuService();
        }

        // Obtiene el menú asignado a un usuario
        public Menu? GetAssignedMenu(User user)
        {
            // Si el usuario es nulo, no se puede asignar un menú
            if (user == null)
                return null;

            return _menuService.GetMenuForUser(user);
        }
    }
}