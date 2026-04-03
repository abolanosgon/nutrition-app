using System;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    public partial class StatisticsForm : Form
    {
        private readonly int? _userId;

        public StatisticsForm()
        {
            InitializeComponent();
            _userId = null;
        }

        public StatisticsForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            StatisticsController controller = new StatisticsController();

            NutritionStatsSummary summary;
            var dailyStats = new System.Collections.Generic.List<DailyCaloriesStat>();
            var topFoods = new System.Collections.Generic.List<TopFoodStat>();

            if (_userId.HasValue)
            {
                summary = controller.GetSummaryByUser(_userId.Value);
                dailyStats = controller.GetDailyCaloriesStatsByUser(_userId.Value);
                topFoods = controller.GetTopFoodsByUser(_userId.Value);
                lblTitle.Text = "Mis estadísticas";
            }
            else
            {
                summary = controller.GetSummary();
                dailyStats = controller.GetDailyCaloriesStats();
                topFoods = controller.GetTopFoods();
                lblTitle.Text = "Resumen de estadísticas";
            }

            lblTotalMealRecords.Text = summary.TotalMealRecords.ToString();
            lblTotalUsersWithRecords.Text = summary.TotalUsersWithRecords.ToString();
            lblTotalCalories.Text = summary.TotalCalories.ToString("F2");
            lblAverageCaloriesPerRecord.Text = summary.AverageCaloriesPerRecord.ToString("F2");
            lblAverageCaloriesPerUser.Text = summary.AverageCaloriesPerUser.ToString("F2");
            lblTotalProtein.Text = summary.TotalProtein.ToString("F2");
            lblTotalCarbs.Text = summary.TotalCarbs.ToString("F2");
            lblTotalFat.Text = summary.TotalFat.ToString("F2");

            dgvDailyStats.DataSource = dailyStats;

            dgvDailyStats.Columns["Date"].HeaderText = "Fecha";
            dgvDailyStats.Columns["TotalCalories"].HeaderText = "Calorías Totales";
            dgvDailyStats.Columns["TotalMeals"].HeaderText = "Total de Comidas";

            dgvDailyStats.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDailyStats.Columns["TotalCalories"].DefaultCellStyle.Format = "F2";

            dgvTopFoods.DataSource = topFoods;

            dgvTopFoods.Columns["FoodName"].HeaderText = "Alimento";
            dgvTopFoods.Columns["TimesConsumed"].HeaderText = "Veces Consumido";
            dgvTopFoods.Columns["TotalQuantity"].HeaderText = "Cantidad Total";
            dgvTopFoods.Columns["TotalCalories"].HeaderText = "Calorías Totales";

            dgvTopFoods.Columns["TotalQuantity"].DefaultCellStyle.Format = "F2";
            dgvTopFoods.Columns["TotalCalories"].DefaultCellStyle.Format = "F2";
        }
    }
}