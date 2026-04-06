using System;
using System.Collections.Generic;
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
            List<DailyCaloriesStat> dailyStats;
            List<TopFoodStat> topFoods;

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

            dgvDailyStats.DataSource = null;
            dgvDailyStats.DataSource = dailyStats;

            if (dgvDailyStats.Columns["Date"] != null)
                dgvDailyStats.Columns["Date"].HeaderText = "Fecha";

            if (dgvDailyStats.Columns["TotalCalories"] != null)
                dgvDailyStats.Columns["TotalCalories"].HeaderText = "Calorías Totales";

            if (dgvDailyStats.Columns["TotalMeals"] != null)
                dgvDailyStats.Columns["TotalMeals"].HeaderText = "Total de Comidas";

            if (dgvDailyStats.Columns["Date"] != null)
                dgvDailyStats.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dgvDailyStats.Columns["TotalCalories"] != null)
                dgvDailyStats.Columns["TotalCalories"].DefaultCellStyle.Format = "F2";

            dgvTopFoods.DataSource = null;
            dgvTopFoods.DataSource = topFoods;

            if (dgvTopFoods.Columns["FoodName"] != null)
                dgvTopFoods.Columns["FoodName"].HeaderText = "Alimento";

            if (dgvTopFoods.Columns["TimesConsumed"] != null)
                dgvTopFoods.Columns["TimesConsumed"].HeaderText = "Veces Consumido";

            if (dgvTopFoods.Columns["TotalQuantity"] != null)
                dgvTopFoods.Columns["TotalQuantity"].HeaderText = "Cantidad Total";

            if (dgvTopFoods.Columns["TotalCalories"] != null)
                dgvTopFoods.Columns["TotalCalories"].HeaderText = "Calorías Totales";

            if (dgvTopFoods.Columns["TotalQuantity"] != null)
                dgvTopFoods.Columns["TotalQuantity"].DefaultCellStyle.Format = "F2";

            if (dgvTopFoods.Columns["TotalCalories"] != null)
                dgvTopFoods.Columns["TotalCalories"].DefaultCellStyle.Format = "F2";
        }
    }
}