using Nutrition_App.Controllers;
using Nutrition_App.Models;
using System;
using System.Windows.Forms;

namespace Nutrition_App.Views
{
    public partial class MainForm : Form
    {
        // Controlador que manejará la lógica relacionada con usuarios
        private UserController userController = new UserController();

        private int selectedUserId = -1;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            userController.EnsureAdminUser();
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            ////////////////////////////////

            if (!ValidateInputs(out int age, out double weight, out double height))
            {
                return;
            }

            ////////////////////////////////

            string gender = GetSelectedGender();

            ////////////////////////////////

            string goal = GetSelectedGoal();

            if (string.IsNullOrEmpty(goal))
            {
                MessageBox.Show("El objetivo seleccionado no es válido.");
                return;
            }

            ////////////////////////////////

            string activityLevel = GetSelectedActivityLevel();


            ////////////////////////////////
            ///

            string dietType = GetSelectedDietType();

            if (string.IsNullOrEmpty(dietType))
            {
                MessageBox.Show("El tipo de dieta seleccionado no es válido.");
                return;
            }

            ////////////////////////////////

            User user = BuildUser(age, weight, height, gender, goal, activityLevel, dietType);

            userController.RegisterUser(user);
            LoadUsers();

            MessageBox.Show("Usuario registrado correctamente.");


            ////////////////////////////////

            ClearForm();

            ////////////////////////////////


        }



        private User BuildUser(int age, double weight, double height, string gender, string goal, string activityLevel, string dietType)
        {
            return new User
            {
                Name = txtName.Text,
                Username = GenerateUsername(txtName.Text, age),
                Password = txtPassword.Text,
                Age = age,
                Weight = weight,
                Height = height,
                Gender = gender,
                Goal = goal,
                ActivityLevel = activityLevel,
                DietType = dietType,
                Role = "User"
            };
        }


        private void ClearForm()
        {
            txtName.Clear();
            txtAge.Clear();
            txtWeight.Clear();
            txtHeight.Clear();
            txtPassword.Clear();
            cmbGender.SelectedIndex = -1;
            cmbGoal.SelectedIndex = -1;
            cmbActivityLevel.SelectedIndex = -1;
            cmbDietType.SelectedIndex = -1;
            txtName.Focus();
        }

        private bool ValidateInputs(out int age, out double weight, out double height)
        {
            age = 0;
            weight = 0;
            height = 0;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Debe ingresar un nombre.");
                return false;
            }

            if (!int.TryParse(txtAge.Text, out age) || age <= 0)
            {
                MessageBox.Show("Debe ingresar una edad válida.");
                return false;
            }

            if (!double.TryParse(txtWeight.Text, out weight) || weight <= 0)
            {
                MessageBox.Show("Debe ingresar un peso válido.");
                return false;
            }

            if (!double.TryParse(txtHeight.Text, out height) || height <= 0)
            {
                MessageBox.Show("Debe ingresar una altura válida.");
                return false;
            }

            if (cmbGender.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un género.");
                return false;
            }

            if (cmbGoal.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un objetivo.");
                return false;
            }

            if (cmbActivityLevel.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un nivel de actividad.");
                return false;
            }

            if (cmbDietType.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de dieta.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña.");
                return false;
            }

            return true;
        }


        private string GetSelectedGender()
        {
            if (cmbGender.SelectedItem.ToString() == "Hombre")
            {
                return "Male";
            }

            if (cmbGender.SelectedItem.ToString() == "Mujer")
            {
                return "Female";
            }

            return "";
        }

        private string GetSelectedGoal()
        {
            string selectedGoal = cmbGoal.SelectedItem.ToString().Trim();

            switch (selectedGoal)
            {
                case "Mantener peso":
                    return "Maintain";

                case "Perder grasa":
                    return "LoseFat";

                case "Ganar masa muscular":
                    return "GainMuscle";

                default:
                    return "";
            }
        }


        private string GetSelectedActivityLevel()
        {
            string selectedActivity = cmbActivityLevel.SelectedItem.ToString();

            switch (selectedActivity)
            {
                case "Sedentario":
                    return "Sedentary";

                case "Ligero":
                    return "Light";

                case "Moderado":
                    return "Moderate";

                case "Activo":
                    return "Active";

                default:
                    return "";
            }
        }

        private string GetSelectedDietType()
        {
            string selectedDiet = cmbDietType.SelectedItem.ToString();

            switch (selectedDiet)
            {
                case "Estándar":
                    return "Standard";

                case "Keto":
                    return "Keto";

                case "Vegetariana":
                    return "Vegetarian";

                default:
                    return "";
            }
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = userController.GetUsers();

            dgvUsers.Columns["Id"].Visible = false;
            dgvUsers.Columns["Password"].Visible = false;

            dgvUsers.Columns["Name"].HeaderText = "Nombre";
            dgvUsers.Columns["Username"].HeaderText = "Usuario";
            dgvUsers.Columns["Age"].HeaderText = "Edad";
            dgvUsers.Columns["Weight"].HeaderText = "Peso";
            dgvUsers.Columns["Height"].HeaderText = "Altura";
            dgvUsers.Columns["Gender"].HeaderText = "Género";
            dgvUsers.Columns["Goal"].HeaderText = "Objetivo";
            dgvUsers.Columns["ActivityLevel"].HeaderText = "Nivel de actividad";
            dgvUsers.Columns["DietType"].HeaderText = "Tipo de dieta";

            TranslateUserGrid();
        }



        private void TranslateUserGrid()
        {
            foreach (DataGridViewRow row in dgvUsers.Rows)
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
            }
        }

        private string GenerateUsername(string name, int age)
        {
            string username = name.Trim().Replace(" ", "").ToLower();
            return username + age;
        }

        private void UpdateUsernamePreview()
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && int.TryParse(txtAge.Text, out int age))
            {
                string username = GenerateUsername(txtName.Text, age);
                lblSelectedUser.Text = "Usuario generado: " + username;
            }
            else
            {
                lblSelectedUser.Text = "Usuario generado: ---";
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            UpdateUsernamePreview();
        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            UpdateUsernamePreview();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvUsers.Rows[e.RowIndex];

                selectedUserId = Convert.ToInt32(row.Cells["Id"].Value);

                string name = row.Cells["Name"].Value?.ToString();

                lblSelectedUser.Text = "Usuario seleccionado: " + name;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLoginUsername.Text))
            {
                MessageBox.Show("Debe ingresar un usuario.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLoginPassword.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña.");
                return;
            }

            User authenticatedUser = userController.AuthenticateUser(txtLoginUsername.Text, txtLoginPassword.Text);

            if (authenticatedUser == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
                return;
            }

            if (authenticatedUser.Role == "Admin")
            {
                AdminForm adminForm = new AdminForm(authenticatedUser);
                adminForm.Show();
                this.Hide();
            }
            else
            {
                UserForm userForm = new UserForm(authenticatedUser);
                userForm.Show();
                this.Hide();
            }
        }
    }
}