using Nutrition_App.Controllers;
using Nutrition_App.Models;
using Nutrition_App.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Nutrition_App.Views
{
    // Formulario principal para usuarios normales.
    // Permite visualizar su información, editar perfil, eliminar cuenta y acceder a módulos como comidas, estadísticas y menú.
    public partial class UserForm : Form
    {
        // Usuario actualmente logueado
        private User? loggedUser;

        // Constructor por defecto
        public UserForm()
        {
            InitializeComponent();
        }

        // Constructor que recibe el usuario logueado
        public UserForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
            LoadLoggedUserData();
            LoadUserGrid();
        }

        // Carga información básica del usuario en la interfaz
        private void LoadLoggedUserData()
        {
            if (loggedUser == null)
            {
                return;
            }

            lblWelcomeUser.Text = "Bienvenido, " + loggedUser.Name;
        }

        // Muestra los datos del usuario en el DataGridView
        private void LoadUserGrid()
        {
            if (loggedUser == null)
            {
                return;
            }

            dgvUserData.DataSource = null;
            dgvUserData.DataSource = new List<User> { loggedUser };

            // Oculta columnas sensibles
            dgvUserData.Columns["Id"].Visible = false;
            dgvUserData.Columns["Password"].Visible = false;

            // Traducción de encabezados
            dgvUserData.Columns["Name"].HeaderText = "Nombre";
            dgvUserData.Columns["Username"].HeaderText = "Usuario";
            dgvUserData.Columns["Age"].HeaderText = "Edad";
            dgvUserData.Columns["Weight"].HeaderText = "Peso";
            dgvUserData.Columns["Height"].HeaderText = "Altura";
            dgvUserData.Columns["Gender"].HeaderText = "Género";
            dgvUserData.Columns["Goal"].HeaderText = "Objetivo";
            dgvUserData.Columns["ActivityLevel"].HeaderText = "Nivel de actividad";
            dgvUserData.Columns["DietType"].HeaderText = "Tipo de dieta";
            dgvUserData.Columns["Role"].HeaderText = "Rol";

            TranslateUserGrid();
        }

        // Traduce valores internos (inglés) a español para mostrar en la tabla
        private void TranslateUserGrid()
        {
            foreach (DataGridViewRow row in dgvUserData.Rows)
            {
                string gender = row.Cells["Gender"].Value?.ToString() ?? "";
                if (gender == "Male") row.Cells["Gender"].Value = "Hombre";
                else if (gender == "Female") row.Cells["Gender"].Value = "Mujer";

                string goal = row.Cells["Goal"].Value?.ToString() ?? "";
                if (goal == "Maintain") row.Cells["Goal"].Value = "Mantener peso";
                else if (goal == "LoseFat") row.Cells["Goal"].Value = "Perder grasa";
                else if (goal == "GainMuscle") row.Cells["Goal"].Value = "Ganar masa muscular";

                string activityLevel = row.Cells["ActivityLevel"].Value?.ToString() ?? "";
                if (activityLevel == "Sedentary") row.Cells["ActivityLevel"].Value = "Sedentario";
                else if (activityLevel == "Light") row.Cells["ActivityLevel"].Value = "Ligero";
                else if (activityLevel == "Moderate") row.Cells["ActivityLevel"].Value = "Moderado";
                else if (activityLevel == "Active") row.Cells["ActivityLevel"].Value = "Activo";

                string dietType = row.Cells["DietType"].Value?.ToString() ?? "";
                if (dietType == "Standard") row.Cells["DietType"].Value = "Estándar";
                else if (dietType == "Keto") row.Cells["DietType"].Value = "Keto";
                else if (dietType == "Vegetarian") row.Cells["DietType"].Value = "Vegetariana";

                string role = row.Cells["Role"].Value?.ToString() ?? "";
                if (role == "Admin") row.Cells["Role"].Value = "Administrador";
                else if (role == "User") row.Cells["Role"].Value = "Usuario";
            }
        }

        // Botón para editar el perfil del usuario
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            if (loggedUser == null)
            {
                MessageBox.Show("No se encontró la información del usuario.");
                return;
            }

            EditUserForm editUserForm = new EditUserForm(loggedUser);
            editUserForm.ShowDialog();

            // Recarga la información después de editar
            LoadLoggedUserData();
            LoadUserGrid();
        }

        // Botón para eliminar la cuenta del usuario
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (loggedUser == null)
            {
                MessageBox.Show("No se encontró el usuario.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Está seguro que desea eliminar su cuenta?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                UserController userController = new UserController();
                userController.DeleteUser(loggedUser.Id);

                MessageBox.Show("Cuenta eliminada correctamente.");

                // Redirige al formulario principal
                MainForm mainForm = new MainForm();
                mainForm.Show();

                this.Close();
            }
        }

        // Botón para cerrar sesión
        private void btnLogout_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();

            this.Close();
        }

        // Abre el módulo de registro de comidas del usuario
        private void btnOpenFoods_Click(object sender, EventArgs e)
        {
            if (loggedUser == null)
            {
                MessageBox.Show("No se encontró el usuario.");
                return;
            }

            UserMealForm userMealForm = new UserMealForm(loggedUser);
            userMealForm.ShowDialog();

            // Refresca datos luego de cambios
            LoadUserGrid();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            //n/a

        }

        // Abre información nutricional calculada del usuario
        private void btnViewNutritionInfo_Click(object sender, EventArgs e)
        {
            if (loggedUser == null)
            {
                MessageBox.Show("No hay usuario cargado.");
                return;
            }

            UserInfoForm form = new UserInfoForm(loggedUser);
            form.ShowDialog();
        }

        // Abre estadísticas personales del usuario
        private void btnViewMyStats_Click(object sender, EventArgs e)
        {
            if (loggedUser == null)
            {
                MessageBox.Show("No se encontró el usuario.");
                return;
            }

            StatisticsForm statisticsForm = new StatisticsForm(loggedUser.Id);
            statisticsForm.ShowDialog();
        }

        // Abre el menú nutricional asignado al usuario
        private void btnViewMenu_Click(object sender, EventArgs e)
        {
            if (loggedUser == null)
            {
                MessageBox.Show("No se encontró el usuario.");
                return;
            }

            MenuForm menuForm = new MenuForm(loggedUser);
            menuForm.ShowDialog();
        }
    }
}