using System;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    public partial class MainForm : Form
    {
        // Controlador que manejará la lógica relacionada con usuarios
        private UserController userController = new UserController();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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
                Age = age,
                Weight = weight,
                Height = height,
                Gender = gender,
                Goal = goal,
                ActivityLevel = activityLevel,
                DietType = dietType
            };
        }


        private void ClearForm()
        {
            txtName.Clear();
            txtAge.Clear();
            txtWeight.Clear();
            txtHeight.Clear();
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


        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}