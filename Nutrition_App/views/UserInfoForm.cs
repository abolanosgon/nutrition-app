using System;
using System.Windows.Forms;
using Nutrition_App.Models;
using Nutrition_App.Services;

namespace Nutrition_App.Views
{
    // Formulario para mostrar la información nutricional calculada del usuario.
    // Presenta datos como IMC, calorías objetivo y distribución de macronutrientes.
    public partial class UserInfoForm : Form
    {
        // Usuario actual del cual se mostrará la información
        private User? currentUser;

        // Servicio encargado de calcular la información nutricional
        private NutritionService nutritionService;

        // Constructor que recibe el usuario logueado
        public UserInfoForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            nutritionService = new NutritionService();
        }

        // Evento de carga del formulario
        // Llama al método que obtiene y muestra la información nutricional
        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            LoadNutritionInfo();
        }

        // Calcula y carga la información nutricional del usuario en la interfaz
        private void LoadNutritionInfo()
        {
            // Validación: debe existir un usuario cargado
            if (currentUser == null)
            {
                MessageBox.Show("No se encontró la información del usuario.");
                this.Close();
                return;
            }

            // Calcula la información nutricional usando el servicio
            NutritionInfo nutritionInfo = nutritionService.CalculateNutritionInfo(currentUser);

            // Muestra los resultados en los labels
            lblUserName.Text = "Usuario: " + currentUser.Name;
            lblBMI.Text = "IMC: " + nutritionInfo.BMI;
            lblMaintenanceCalories.Text = "Calorías de mantenimiento: " + nutritionInfo.MaintenanceCalories + " kcal";
            lblTargetCalories.Text = "Calorías objetivo: " + nutritionInfo.TargetCalories + " kcal";
            lblProtein.Text = "Proteínas: " + nutritionInfo.ProteinGrams + " g";
            lblCarbs.Text = "Carbohidratos: " + nutritionInfo.CarbsGrams + " g";
            lblFats.Text = "Grasas: " + nutritionInfo.FatsGrams + " g";

            // Traduce valores internos a un formato más amigable para el usuario
            lblGoal.Text = "Objetivo: " + TranslateGoal(currentUser.Goal);
            lblDietType.Text = "Tipo de dieta: " + TranslateDietType(currentUser.DietType);
            lblActivityLevel.Text = "Nivel de actividad: " + TranslateActivityLevel(currentUser.ActivityLevel);
        }

        // Traduce el objetivo del usuario a español
        private static string TranslateGoal(string goal)
        {
            switch (goal)
            {
                case "Maintain":
                    return "Mantener peso";
                case "LoseFat":
                    return "Perder grasa";
                case "GainMuscle":
                    return "Ganar masa muscular";
                default:
                    return goal;
            }
        }

        // Traduce el tipo de dieta a español
        private static string TranslateDietType(string dietType)
        {
            switch (dietType)
            {
                case "Standard":
                    return "Estándar";
                case "Keto":
                    return "Keto";
                case "Vegetarian":
                    return "Vegetariana";
                default:
                    return dietType;
            }
        }

        // Traduce el nivel de actividad a español
        private static string TranslateActivityLevel(string activityLevel)
        {
            switch (activityLevel)
            {
                case "Sedentary":
                    return "Sedentario";
                case "Light":
                    return "Ligero";
                case "Moderate":
                    return "Moderado";
                case "Active":
                    return "Activo";
                default:
                    return activityLevel;
            }
        }
    }
}