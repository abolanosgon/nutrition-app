using System;
using System.Windows.Forms;
using Nutrition_App.Models;
using Nutrition_App.Services;

namespace Nutrition_App.Views
{
    public partial class UserInfoForm : Form
    {
        private User currentUser;
        private NutritionService nutritionService;

        public UserInfoForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            nutritionService = new NutritionService();
        }

        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            LoadNutritionInfo();
        }

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

        private string TranslateGoal(string goal)
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

        private string TranslateDietType(string dietType)
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

        private string TranslateActivityLevel(string activityLevel)
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