using Nutrition_App.Controllers;
using Nutrition_App.Models;
using Nutrition_App.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Nutrition_App.Views
{
    /// <summary>
    /// Formulario principal para usuarios estándar.
    /// Permite visualizar la información personal del usuario autenticado,
    /// editar su perfil, eliminar su cuenta, registrar comidas, consultar
    /// información nutricional, ver estadísticas personales y consultar su menú asignado.
    /// </summary>
    public partial class UserForm : Form
    {
        private User? loggedUser;

        /// <summary>
        /// Inicializa una nueva instancia del formulario de usuario.
        /// </summary>
        public UserForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicializa una nueva instancia del formulario de usuario
        /// con la información del usuario autenticado.
        /// </summary>
        /// <param name="user">Usuario que ha iniciado sesión.</param>
        public UserForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
            LoadLoggedUserData();
            LoadUserGrid();
        }

        /// <summary>
        /// Carga en la interfaz la información básica del usuario autenticado.
        /// </summary>
        private void LoadLoggedUserData()
        {
            if (loggedUser == null)
            {
                return;
            }

            lblWelcomeUser.Text = "Bienvenido, " + loggedUser.Name;
        }

        /// <summary>
        /// Carga los datos del usuario autenticado en la grilla y ajusta
        /// los encabezados visibles para presentación.
        /// </summary>
        private void LoadUserGrid()
        {
            if (loggedUser == null)
            {
                return;
            }

            dgvUserData.DataSource = null;
            dgvUserData.DataSource = new List<User> { loggedUser };

            dgvUserData.Columns["Id"].Visible = false;
            dgvUserData.Columns["Password"].Visible = false;

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

        /// <summary>
        /// Traduce en la grilla los valores internos del sistema a etiquetas legibles en español.
        /// </summary>
        private void TranslateUserGrid()
        {
            foreach (DataGridViewRow row in dgvUserData.Rows)
            {
                string gender = row.Cells["Gender"].Value?.ToString() ?? "";
                if (gender == "Male")
                {
                    row.Cells["Gender"].Value = "Hombre";
                }
                else if (gender == "Female")
                {
                    row.Cells["Gender"].Value = "Mujer";
                }

                string goal = row.Cells["Goal"].Value?.ToString() ?? "";
                if (goal == "Maintain")
                {
                    row.Cells["Goal"].Value = "Mantener peso";
                }
                else if (goal == "LoseFat")
                {
                    row.Cells["Goal"].Value = "Perder grasa";
                }
                else if (goal == "GainMuscle")
                {
                    row.Cells["Goal"].Value = "Ganar masa muscular";
                }

                string activityLevel = row.Cells["ActivityLevel"].Value?.ToString() ?? "";
                if (activityLevel == "Sedentary")
                {
                    row.Cells["ActivityLevel"].Value = "Sedentario";
                }
                else if (activityLevel == "Light")
                {
                    row.Cells["ActivityLevel"].Value = "Ligero";
                }
                else if (activityLevel == "Moderate")
                {
                    row.Cells["ActivityLevel"].Value = "Moderado";
                }
                else if (activityLevel == "Active")
                {
                    row.Cells["ActivityLevel"].Value = "Activo";
                }

                string dietType = row.Cells["DietType"].Value?.ToString() ?? "";
                if (dietType == "Standard")
                {
                    row.Cells["DietType"].Value = "Estándar";
                }
                else if (dietType == "Keto")
                {
                    row.Cells["DietType"].Value = "Keto";
                }
                else if (dietType == "Vegetarian")
                {
                    row.Cells["DietType"].Value = "Vegetariana";
                }

                string role = row.Cells["Role"].Value?.ToString() ?? "";
                if (role == "Admin")
                {
                    row.Cells["Role"].Value = "Administrador";
                }
                else if (role == "User")
                {
                    row.Cells["Role"].Value = "Usuario";
                }
            }
        }

        /// <summary>
        /// Abre el formulario de edición del perfil del usuario autenticado
        /// y actualiza la información mostrada al cerrarlo.
        /// </summary>
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            if (loggedUser == null)
            {
                MessageBox.Show("No se encontró la información del usuario.");
                return;
            }

            EditUserForm editUserForm = new EditUserForm(loggedUser);
            editUserForm.ShowDialog();

            LoadLoggedUserData();
            LoadUserGrid();
        }

        /// <summary>
        /// Elimina la cuenta del usuario autenticado previa confirmación
        /// y redirige al formulario principal.
        /// </summary>
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

                MainForm mainForm = new MainForm();
                mainForm.Show();

                this.Close();
            }
        }

        /// <summary>
        /// Cierra la sesión actual y regresa al formulario principal.
        /// </summary>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();

            this.Close();
        }

        /// <summary>
        /// Abre el formulario de registro y consulta de comidas del usuario autenticado.
        /// </summary>
        private void btnOpenFoods_Click(object sender, EventArgs e)
        {
            if (loggedUser == null)
            {
                MessageBox.Show("No se encontró el usuario.");
                return;
            }

            UserMealForm userMealForm = new UserMealForm(loggedUser);
            userMealForm.ShowDialog();

            LoadUserGrid();
        }

        /// <summary>
        /// Evento reservado para futuras inicializaciones del formulario de usuario.
        /// </summary>
        private void UserForm_Load(object sender, EventArgs e)
        {
            // Evento reservado para futuras inicializaciones del formulario.
        }

        /// <summary>
        /// Abre la ventana con la información nutricional calculada para el usuario autenticado.
        /// </summary>
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

        /// <summary>
        /// Abre la ventana de estadísticas personales del usuario autenticado.
        /// </summary>
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

        /// <summary>
        /// Abre la ventana del menú asignado al usuario autenticado.
        /// </summary>
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