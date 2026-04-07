using System;
using System.Windows.Forms;
using Nutrition_App.Models;
using Nutrition_App.Services;

namespace Nutrition_App.Views
{
    /// <summary>
    /// Formulario encargado de mostrar la información nutricional calculada
    /// para el usuario autenticado.
    /// </summary>
    public partial class UserInfoForm : Form
    {
        private User? currentUser;
        private NutritionService nutritionService;

        /// <summary>
        /// Inicializa una nueva instancia del formulario de información nutricional
        /// para el usuario indicado.
        /// </summary>
        /// <param name="user">Usuario del que se desea mostrar la información nutricional.</param>
        public UserInfoForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            nutritionService = new NutritionService();
        }

        /// <summary>
        /// Ejecuta la carga de información nutricional al iniciar el formulario.
        /// </summary>
        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            LoadNutritionInfo();
        }

        /// <summary>
        /// Calcula y muestra la información nutricional del usuario actual,
        /// incluyendo calorías, macronutrientes y datos traducidos para la interfaz.
        /// </summary>
        private void LoadNutritionInfo()
        {
            if (currentUser == null)
            {
                MessageBox.Show("No se encontró la información del usuario.");
                this.Close();
                return;
            }

            NutritionInfo nutritionInfo = nutritionService.CalculateNutritionInfo(currentUser);

            lblUserName.Text = "Usuario: " + currentUser.Name;
            lblBMI.Text = "IMC: " + nutritionInfo.BMI;
            lblMaintenanceCalories.Text = "Calorías de mantenimiento: " + nutritionInfo.MaintenanceCalories + " kcal";
            lblTargetCalories.Text = "Calorías objetivo: " + nutritionInfo.TargetCalories + " kcal";
            lblProtein.Text = "Proteínas: " + nutritionInfo.ProteinGrams + " g";
            lblCarbs.Text = "Carbohidratos: " + nutritionInfo.CarbsGrams + " g";
            lblFats.Text = "Grasas: " + nutritionInfo.FatsGrams + " g";
            lblGoal.Text = "Objetivo: " + TranslateGoal(currentUser.Goal);
            lblDietType.Text = "Tipo de dieta: " + TranslateDietType(currentUser.DietType);
            lblActivityLevel.Text = "Nivel de actividad: " + TranslateActivityLevel(currentUser.ActivityLevel);
        }

        /// <summary>
        /// Traduce el objetivo nutricional desde el valor interno del sistema
        /// a su representación visible en español.
        /// </summary>
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

        /// <summary>
        /// Traduce el tipo de dieta desde el valor interno del sistema
        /// a su representación visible en español.
        /// </summary>
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

        /// <summary>
        /// Traduce el nivel de actividad desde el valor interno del sistema
        /// a su representación visible en español.
        /// </summary>
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