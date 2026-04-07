using System;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    // Formulario de administración.
    // Permite visualizar, editar y eliminar usuarios, así como acceder a módulos adicionales.
    public partial class AdminForm : Form
    {
        // Usuario actualmente logueado (admin)
        private User? loggedUser;

        // Controlador para manejar operaciones de usuarios
        private UserController userController = new UserController();

        // Id del usuario seleccionado en el DataGridView
        private int selectedUserId = -1;

        // Constructor por defecto
        // Carga la lista de usuarios al iniciar
        public AdminForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        // Constructor con usuario logueado
        // Se utiliza cuando se accede desde login
        public AdminForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
            LoadUsers();
        }

        // Carga todos los usuarios en el DataGridView
        private void LoadUsers()
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = userController.GetUsers();
        }

        // Evento al hacer clic en una fila del DataGridView
        // Obtiene el Id del usuario seleccionado
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

        // Botón para eliminar usuario seleccionado
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // Validación: debe haber un usuario seleccionado
            if (selectedUserId == -1)
            {
                MessageBox.Show("Debe seleccionar un usuario.");
                return;
            }

            // Validación: evitar que el admin se elimine a sí mismo
            if (loggedUser != null && selectedUserId == loggedUser.Id)
            {
                MessageBox.Show("No puede eliminar su propio usuario administrador.");
                return;
            }

            // Confirmación antes de eliminar
            DialogResult result = MessageBox.Show(
                "¿Está seguro de eliminar este usuario?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // Eliminación del usuario
            if (result == DialogResult.Yes)
            {
                userController.DeleteUser(selectedUserId);
                LoadUsers(); // refresca la lista
                selectedUserId = -1;
                MessageBox.Show("Usuario eliminado correctamente.");
            }
        }

        // Botón para editar usuario seleccionado
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            // Validación: debe haber un usuario seleccionado
            if (selectedUserId == -1)
            {
                MessageBox.Show("Debe seleccionar un usuario.");
                return;
            }

            // Obtiene el usuario por Id
            User? selectedUser = userController.GetUserById(selectedUserId);

            if (selectedUser == null)
            {
                MessageBox.Show("No se encontró el usuario.");
                return;
            }

            // Abre formulario de edición
            EditUserForm editForm = new EditUserForm(selectedUser);
            editForm.ShowDialog();

            // Refresca datos luego de editar
            LoadUsers();
        }

        // Abre el módulo de gestión de alimentos
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

        // Botón de prueba para mostrar estadísticas generales
        // Llama al controlador de estadísticas y muestra un resumen
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

        private void AdminForm_Load(object sender, EventArgs e)
        {
            //N/A
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();

            this.Close();
        }
    }
}