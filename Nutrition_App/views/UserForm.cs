using Nutrition_App.Controllers;
using Nutrition_App.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Nutrition_App.Views
{
    public partial class UserForm : Form
    {
        private User loggedUser;

        public UserForm()
        {
            InitializeComponent();
        }

        public UserForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
            LoadLoggedUserData();
            LoadUserGrid();
        }

        private void LoadLoggedUserData()
        {
            if (loggedUser == null)
            {
                return;
            }

            lblWelcomeUser.Text = "Bienvenido, " + loggedUser.Name;
        }

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

        private void TranslateUserGrid()
        {
            foreach (DataGridViewRow row in dgvUserData.Rows)
            {
                if (row.Cells["Gender"].Value != null)
                {
                    string gender = row.Cells["Gender"].Value.ToString();

                    if (gender == "Male")
                    {
                        row.Cells["Gender"].Value = "Hombre";
                    }
                    else if (gender == "Female")
                    {
                        row.Cells["Gender"].Value = "Mujer";
                    }
                }

                if (row.Cells["Goal"].Value != null)
                {
                    string goal = row.Cells["Goal"].Value.ToString();

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
                }

                if (row.Cells["ActivityLevel"].Value != null)
                {
                    string activityLevel = row.Cells["ActivityLevel"].Value.ToString();

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
                }

                if (row.Cells["DietType"].Value != null)
                {
                    string dietType = row.Cells["DietType"].Value.ToString();

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
                }

                if (row.Cells["Role"].Value != null)
                {
                    string role = row.Cells["Role"].Value.ToString();

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
        }

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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();

            this.Close();
        }
    }
}