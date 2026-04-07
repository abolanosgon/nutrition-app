using System;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    /// <summary>
    /// Formulario de administración del sistema.
    /// Permite visualizar usuarios registrados, editar cuentas, eliminar usuarios,
    /// acceder al módulo de alimentos, consultar estadísticas generales y volver al formulario principal.
    /// </summary>
    public partial class AdminForm : Form
    {
        private User? loggedUser;
        private UserController userController = new UserController();
        private int selectedUserId = -1;

        /// <summary>
        /// Inicializa una nueva instancia del formulario de administración.
        /// </summary>
        public AdminForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        /// <summary>
        /// Inicializa una nueva instancia del formulario de administración
        /// con el usuario autenticado actualmente.
        /// </summary>
        /// <param name="user">Usuario administrador que inició sesión.</param>
        public AdminForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
            LoadUsers();
        }

        /// <summary>
        /// Carga la lista de usuarios registrados en la grilla del formulario.
        /// </summary>
        private void LoadUsers()
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = userController.GetUsers();
        }

        /// <summary>
        /// Captura el identificador del usuario seleccionado en la grilla.
        /// </summary>
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvUsers.Rows[e.RowIndex];
                object? idValue = row.Cells["Id"].Value;

                if (idValue != null && int.TryParse(idValue.ToString(), out int id))
                {
                    selectedUserId = id;
                }
            }
        }

        /// <summary>
        /// Elimina el usuario seleccionado de la lista, evitando que el administrador
        /// elimine su propia cuenta.
        /// </summary>
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Debe seleccionar un usuario.");
                return;
            }

            if (loggedUser != null && selectedUserId == loggedUser.Id)
            {
                MessageBox.Show("No puede eliminar su propio usuario administrador.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Está seguro de eliminar este usuario?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                userController.DeleteUser(selectedUserId);
                LoadUsers();
                selectedUserId = -1;
                MessageBox.Show("Usuario eliminado correctamente.");
            }
        }

        /// <summary>
        /// Abre el formulario de edición para el usuario seleccionado y recarga la lista
        /// una vez cerrada la ventana de edición.
        /// </summary>
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Debe seleccionar un usuario.");
                return;
            }

            User? selectedUser = userController.GetUserById(selectedUserId);

            if (selectedUser == null)
            {
                MessageBox.Show("No se encontró el usuario.");
                return;
            }

            EditUserForm editForm = new EditUserForm(selectedUser);
            editForm.ShowDialog();

            LoadUsers();
        }

        /// <summary>
        /// Abre el módulo de gestión de alimentos utilizando el usuario autenticado.
        /// </summary>
        private void btnOpenFoods_Click(object sender, EventArgs e)
        {
            if (loggedUser == null)
            {
                MessageBox.Show("No se encontró el usuario.");
                return;
            }

            FoodForm foodForm = new FoodForm(loggedUser);
            foodForm.ShowDialog();
        }

        /// <summary>
        /// Muestra un resumen general de estadísticas nutricionales calculadas a partir
        /// de los registros de comida existentes en el sistema.
        /// </summary>
        private void btnTestStats_Click(object sender, EventArgs e)
        {
            StatisticsController controller = new StatisticsController();
            NutritionStatsSummary summary = controller.GetSummary();

            MessageBox.Show(
                "Total registros: " + summary.TotalMealRecords +
                "\nUsuarios con registros: " + summary.TotalUsersWithRecords +
                "\nCalorías totales: " + summary.TotalCalories +
                "\nPromedio por registro: " + summary.AverageCaloriesPerRecord +
                "\nPromedio por usuario: " + summary.AverageCaloriesPerUser +
                "\nProteína total: " + summary.TotalProtein +
                "\nCarbohidratos totales: " + summary.TotalCarbs +
                "\nGrasa total: " + summary.TotalFat,
                "Resumen de estadísticas"
            );
        }

        /// <summary>
        /// Cierra el formulario de administración y regresa al formulario principal.
        /// </summary>
        private void btnVolverMain_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Close();
        }
    }
}