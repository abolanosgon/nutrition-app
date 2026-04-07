using Nutrition_App.Controllers;
using Nutrition_App.Models;
using System;
using System.Windows.Forms;
using Nutrition_App.Services;

namespace Nutrition_App.Views
{
    /// <summary>
    /// Formulario principal de la aplicación.
    /// Permite registrar usuarios, visualizar la lista de usuarios existentes,
    /// iniciar sesión y cargar datos base para pruebas o reinicialización.
    /// </summary>
    public partial class MainForm : Form
    {
        private UserController userController = new UserController();

        /// <summary>
        /// Inicializa una nueva instancia del formulario principal.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ejecuta la configuración inicial del formulario al cargarse,
        /// asegurando la existencia del usuario administrador y cargando los usuarios registrados.
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            userController.EnsureAdminUser();
            LoadUsers();
        }

        /// <summary>
        /// Registra un nuevo usuario a partir de los datos ingresados en el formulario.
        /// Valida entradas, traduce valores visuales a valores internos y actualiza la lista.
        /// </summary>
        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out int age, out double weight, out double height))
            {
                return;
            }

            string gender = GetSelectedGender();

            string goal = GetSelectedGoal();

            if (string.IsNullOrEmpty(goal))
            {
                MessageBox.Show("El objetivo seleccionado no es válido.");
                return;
            }

            string activityLevel = GetSelectedActivityLevel();

            string dietType = GetSelectedDietType();

            if (string.IsNullOrEmpty(dietType))
            {
                MessageBox.Show("El tipo de dieta seleccionado no es válido.");
                return;
            }

            User user = BuildUser(age, weight, height, gender, goal, activityLevel, dietType);

            userController.RegisterUser(user);
            LoadUsers();

            MessageBox.Show("Usuario registrado correctamente.");

            ClearForm();
        }

        /// <summary>
        /// Construye una instancia de <see cref="User"/> con la información ingresada
        /// y los valores internos requeridos por el sistema.
        /// </summary>
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

        /// <summary>
        /// Limpia los controles del formulario de registro y devuelve el foco al campo de nombre.
        /// </summary>
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

        /// <summary>
        /// Valida los datos ingresados en el formulario antes de registrar un usuario.
        /// </summary>
        /// <param name="age">Edad validada del usuario.</param>
        /// <param name="weight">Peso validado del usuario.</param>
        /// <param name="height">Altura validada del usuario.</param>
        /// <returns>True si todos los datos son válidos; en caso contrario, false.</returns>
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

        /// <summary>
        /// Traduce el género seleccionado en la interfaz al valor interno utilizado por el sistema.
        /// </summary>
        private string GetSelectedGender()
        {
            string selected = cmbGender.SelectedItem?.ToString() ?? "";

            if (selected == "Hombre")
            {
                return "Male";
            }

            if (selected == "Mujer")
            {
                return "Female";
            }

            return "";
        }

        /// <summary>
        /// Traduce el objetivo seleccionado en la interfaz al valor interno utilizado por el sistema.
        /// </summary>
        private string GetSelectedGoal()
        {
            string selectedGoal = cmbGoal.SelectedItem?.ToString()?.Trim() ?? "";

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

        /// <summary>
        /// Traduce el nivel de actividad seleccionado en la interfaz al valor interno utilizado por el sistema.
        /// </summary>
        private string GetSelectedActivityLevel()
        {
            string selectedActivity = cmbActivityLevel.SelectedItem?.ToString() ?? "";

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

        /// <summary>
        /// Traduce el tipo de dieta seleccionado en la interfaz al valor interno utilizado por el sistema.
        /// </summary>
        private string GetSelectedDietType()
        {
            string selectedDiet = cmbDietType.SelectedItem?.ToString() ?? "";

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

        /// <summary>
        /// Carga los usuarios registrados en la grilla principal y ajusta los encabezados visibles.
        /// </summary>
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

        /// <summary>
        /// Traduce los valores internos mostrados en la grilla a etiquetas legibles en español.
        /// </summary>
        private void TranslateUserGrid()
        {
            foreach (DataGridViewRow row in dgvUsers.Rows)
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
            }
        }

        /// <summary>
        /// Genera automáticamente un nombre de usuario a partir del nombre y la edad.
        /// </summary>
        private static string GenerateUsername(string name, int age)
        {
            string username = name.Trim().Replace(" ", "").ToLower();
            return username + age;
        }

        /// <summary>
        /// Actualiza la vista previa del nombre de usuario generado automáticamente.
        /// </summary>
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

        /// <summary>
        /// Recalcula la vista previa del nombre de usuario cuando cambia el nombre.
        /// </summary>
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            UpdateUsernamePreview();
        }

        /// <summary>
        /// Recalcula la vista previa del nombre de usuario cuando cambia la edad.
        /// </summary>
        private void txtAge_TextChanged(object sender, EventArgs e)
        {
            UpdateUsernamePreview();
        }

        /// <summary>
        /// Muestra en la interfaz el nombre del usuario seleccionado en la grilla.
        /// </summary>
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvUsers.Rows[e.RowIndex];

                string name = row.Cells["Name"].Value?.ToString() ?? "";

                lblSelectedUser.Text = "Usuario seleccionado: " + name;
            }
        }

        /// <summary>
        /// Autentica al usuario con las credenciales ingresadas y abre el formulario correspondiente según su rol.
        /// </summary>
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

            User? authenticatedUser = userController.AuthenticateUser(txtLoginUsername.Text, txtLoginPassword.Text);

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

        /// <summary>
        /// Ejecuta la carga de datos base del sistema, reemplazando los usuarios y registros actuales previa confirmación.
        /// </summary>
        private void btnSeedData_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Esto reemplazará los usuarios y registros de comida actuales. ¿Desea continuar?",
                "Confirmar carga de datos",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                DataSeeder seeder = new DataSeeder();
                seeder.SeedAllData();

                LoadUsers();

                MessageBox.Show("Datos base cargados correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos: " + ex.Message);
            }
        }
    }
}