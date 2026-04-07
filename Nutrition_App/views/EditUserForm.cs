using System;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    // Formulario para editar la información de un usuario existente.
    // Permite modificar datos personales y preferencias (objetivo, dieta, etc.).
    public partial class EditUserForm : Form
    {
        // Usuario seleccionado que se va a editar
        private User? selectedUser;

        // Controlador para manejar operaciones de usuarios
        private UserController userController = new UserController();

        // Constructor por defecto
        public EditUserForm()
        {
            InitializeComponent();
        }

        // Constructor que recibe el usuario a editar
        public EditUserForm(User user)
        {
            InitializeComponent();
            selectedUser = user;
            LoadUserData();
        }

        // Carga los datos del usuario en los campos del formulario
        private void LoadUserData()
        {
            if (selectedUser == null)
            {
                return;
            }

            txtName.Text = selectedUser.Name;
            txtAge.Text = selectedUser.Age.ToString();
            txtWeight.Text = selectedUser.Weight.ToString();
            txtHeight.Text = selectedUser.Height.ToString();

            // Traduce valores internos (inglés) a valores visibles (español)
            cmbGender.SelectedItem = TranslateGenderToSpanish(selectedUser.Gender);
            cmbGoal.SelectedItem = TranslateGoalToSpanish(selectedUser.Goal);
            cmbActivityLevel.SelectedItem = TranslateActivityLevelToSpanish(selectedUser.ActivityLevel);
            cmbDietType.SelectedItem = TranslateDietTypeToSpanish(selectedUser.DietType);
        }

        // Traduce género a español para mostrar en UI
        private static string TranslateGenderToSpanish(string gender)
        {
            switch (gender?.Trim().ToLower())
            {
                case "male":
                case "hombre":
                    return "Hombre";

                case "female":
                case "mujer":
                    return "Mujer";

                default:
                    return "";
            }
        }

        // Traduce objetivo a español para mostrar en UI
        private static string TranslateGoalToSpanish(string goal)
        {
            switch (goal?.Trim().ToLower())
            {
                case "maintain":
                case "mantener":
                case "mantener peso":
                    return "Mantener peso";

                case "losefat":
                case "lose fat":
                case "perder grasa":
                case "perder peso":
                case "bajar grasa":
                    return "Perder grasa";

                case "gainmuscle":
                case "gain muscle":
                case "ganar masa":
                case "ganar masa muscular":
                case "ganar peso":
                case "aumentar peso":
                    return "Ganar masa muscular";

                default:
                    return "";
            }
        }

        // Traduce nivel de actividad a español
        private static string TranslateActivityLevelToSpanish(string activityLevel)
        {
            switch (activityLevel?.Trim().ToLower())
            {
                case "sedentary":
                case "sedentario":
                    return "Sedentario";

                case "light":
                case "ligero":
                    return "Ligero";

                case "moderate":
                case "moderado":
                    return "Moderado";

                case "active":
                case "activo":
                    return "Activo";

                default:
                    return "";
            }
        }

        // Traduce tipo de dieta a español
        private static string TranslateDietTypeToSpanish(string dietType)
        {
            switch (dietType?.Trim().ToLower())
            {
                case "standard":
                case "estandar":
                case "estándar":
                case "estadanr":
                    return "Estándar";

                case "keto":
                    return "Keto";

                case "vegetarian":
                case "vegetariano":
                case "vegetariana":
                    return "Vegetariana";

                default:
                    return "";
            }
        }

        // Evento del botón para guardar cambios del usuario
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // Validación: usuario debe existir
            if (selectedUser == null)
            {
                MessageBox.Show("No se encontró el usuario.");
                return;
            }

            // Validación de campos básicos
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Debe ingresar un nombre.");
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Debe ingresar una edad válida.");
                return;
            }

            if (!double.TryParse(txtWeight.Text, out double weight) || weight <= 0)
            {
                MessageBox.Show("Debe ingresar un peso válido.");
                return;
            }

            if (!double.TryParse(txtHeight.Text, out double height) || height <= 0)
            {
                MessageBox.Show("Debe ingresar una altura válida.");
                return;
            }

            // Validación de combos
            if (cmbGender.SelectedItem == null || cmbGoal.SelectedItem == null ||
                cmbActivityLevel.SelectedItem == null || cmbDietType.SelectedItem == null)
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }

            // Asignación de valores actualizados
            selectedUser.Name = txtName.Text;
            selectedUser.Age = age;
            selectedUser.Weight = weight;
            selectedUser.Height = height;

            // Conversión de UI (español) a valores internos (inglés)
            selectedUser.Gender = cmbGender.SelectedItem?.ToString() == "Hombre" ? "Male" : "Female";

            switch (cmbGoal.SelectedItem?.ToString() ?? "")
            {
                case "Mantener peso":
                    selectedUser.Goal = "Maintain";
                    break;
                case "Perder grasa":
                    selectedUser.Goal = "LoseFat";
                    break;
                case "Ganar masa muscular":
                    selectedUser.Goal = "GainMuscle";
                    break;
            }

            switch (cmbActivityLevel.SelectedItem?.ToString() ?? "")
            {
                case "Sedentario":
                    selectedUser.ActivityLevel = "Sedentary";
                    break;
                case "Ligero":
                    selectedUser.ActivityLevel = "Light";
                    break;
                case "Moderado":
                    selectedUser.ActivityLevel = "Moderate";
                    break;
                case "Activo":
                    selectedUser.ActivityLevel = "Active";
                    break;
            }

            switch (cmbDietType.SelectedItem?.ToString() ?? "")
            {
                case "Estándar":
                    selectedUser.DietType = "Standard";
                    break;
                case "Keto":
                    selectedUser.DietType = "Keto";
                    break;
                case "Vegetariana":
                    selectedUser.DietType = "Vegetarian";
                    break;
            }

            // Actualiza el usuario en el repositorio
            userController.UpdateUser(selectedUser);

            MessageBox.Show("Usuario actualizado correctamente.");
            this.Close();
        }

        // Evento de carga del formulario (no utilizado actualmente)
        private static void EditUserForm_Load(object sender, EventArgs e)
        {
            // n/a
        }
    }
}