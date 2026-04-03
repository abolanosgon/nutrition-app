using System;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;
using System;
using System.Windows.Forms;

namespace Nutrition_App.Views
{
    public partial class AdminForm : Form
    {
        private User loggedUser;
        private UserController userController = new UserController();
        private int selectedUserId = -1;

        public AdminForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        public AdminForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
            LoadUsers();
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = userController.GetUsers();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvUsers.Rows[e.RowIndex];
                selectedUserId = Convert.ToInt32(row.Cells["Id"].Value);
            }
        }

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

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Debe seleccionar un usuario.");
                return;
            }

            User selectedUser = userController.GetUserById(selectedUserId);

            if (selectedUser == null)
            {
                MessageBox.Show("No se encontró el usuario.");
                return;
            }

            EditUserForm editForm = new EditUserForm(selectedUser);
            editForm.ShowDialog();

            LoadUsers();
        }

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
    }
}