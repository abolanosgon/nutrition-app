using System;
using System.Linq;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;
using Nutrition_App.Repositories;

namespace Nutrition_App.Views
{
    // Formulario para mostrar el menú asignado al usuario logueado.
    // Busca el menú según objetivo y tipo de dieta, y muestra su detalle nutricional.
    public partial class MenuForm : Form
    {
        // Usuario actualmente logueado
        private readonly User _loggedUser;

        // Controlador encargado de obtener el menú correspondiente al usuario
        private readonly MenuController _menuController;

        // Repositorio de alimentos para obtener el detalle de cada alimento del menú
        private readonly FoodJsonRepository _foodRepository;

        // Constructor que recibe el usuario logueado
        public MenuForm(User loggedUser)
        {
            InitializeComponent();
            _loggedUser = loggedUser;
            _menuController = new MenuController();
            _foodRepository = new FoodJsonRepository();

            // Carga el menú asignado al abrir el formulario
            LoadAssignedMenu();
        }

        // Busca el menú correspondiente al usuario y lo muestra en pantalla
        private void LoadAssignedMenu()
        {
            var menu = _menuController.GetAssignedMenu(_loggedUser);

            // Si no existe un menú para el usuario, limpia la vista y muestra mensaje
            if (menu == null)
            {
                MessageBox.Show("No se encontró un menú asignado para este usuario.");
                lblMenuName.Text = "Sin menú asignado";
                lblGoal.Text = "Objetivo: ---";
                lblDietType.Text = "Tipo de dieta: ---";
                dgvMenu.DataSource = null;
                return;
            }

            // Muestra información general del menú
            lblMenuName.Text = menu.Name;
            lblGoal.Text = $"Objetivo: {menu.Goal}";
            lblDietType.Text = $"Tipo de dieta: {menu.DietType}";

            // Obtiene todos los alimentos disponibles para relacionarlos con los items del menú
            var foods = _foodRepository.GetAll();

            // Construye la lista detallada del menú
            var menuDetails = menu.Items.Select(item =>
            {
                var food = foods.FirstOrDefault(f => f.Id == item.FoodId);

                return new
                {
                    TiempoDeComida = item.MealType,
                    Alimento = food?.Name ?? "No encontrado",
                    Cantidad = item.Quantity,
                    Calorias = food != null ? food.Calories * item.Quantity : 0,
                    Proteina = food != null ? food.Protein * item.Quantity : 0,
                    Carbohidratos = food != null ? food.Carbohydrates * item.Quantity : 0,
                    Grasas = food != null ? food.Fat * item.Quantity : 0
                };
            }).ToList();

            // Carga los datos en la tabla
            dgvMenu.DataSource = null;
            dgvMenu.DataSource = menuDetails;
        }
    }
}