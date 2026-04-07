using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    // Formulario para mostrar estadísticas nutricionales.
    // Puede mostrar estadísticas globales o estadísticas específicas de un usuario.
    public partial class StatisticsForm : Form
    {
        // Id del usuario para filtrar estadísticas.
        // Si es null, se muestran estadísticas generales.
        private readonly int? _userId;

        // Constructor para estadísticas generales
        public StatisticsForm()
        {
            InitializeComponent();
            _userId = null;
        }

        // Constructor para estadísticas de un usuario específico
        public StatisticsForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        // Evento de carga del formulario
        // Obtiene y muestra el resumen general, estadísticas diarias y alimentos más consumidos
        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            StatisticsController controller = new StatisticsController();

            NutritionStatsSummary summary;
            List<DailyCaloriesStat> dailyStats;
            List<TopFoodStat> topFoods;

            // Si existe userId, se cargan estadísticas filtradas por usuario
            if (_userId.HasValue)
            {
                summary = controller.GetSummaryByUser(_userId.Value);
                dailyStats = controller.GetDailyCaloriesStatsByUser(_userId.Value);
                topFoods = controller.GetTopFoodsByUser(_userId.Value);
                lblTitle.Text = "Mis estadísticas";
            }
            else
            {
                // Si no, se cargan estadísticas generales del sistema
                summary = controller.GetSummary();
                dailyStats = controller.GetDailyCaloriesStats();
                topFoods = controller.GetTopFoods();
                lblTitle.Text = "Resumen de estadísticas";
            }

            // Carga resumen numérico en labels
            lblTotalMealRecords.Text = summary.TotalMealRecords.ToString();
            lblTotalUsersWithRecords.Text = summary.TotalUsersWithRecords.ToString();
            lblTotalCalories.Text = summary.TotalCalories.ToString("F2");
            lblAverageCaloriesPerRecord.Text = summary.AverageCaloriesPerRecord.ToString("F2");
            lblAverageCaloriesPerUser.Text = summary.AverageCaloriesPerUser.ToString("F2");
            lblTotalProtein.Text = summary.TotalProtein.ToString("F2");
            lblTotalCarbs.Text = summary.TotalCarbs.ToString("F2");
            lblTotalFat.Text = summary.TotalFat.ToString("F2");

            // Carga estadísticas diarias en el DataGridView
            dgvDailyStats.DataSource = null;
            dgvDailyStats.DataSource = dailyStats;

            // Configuración de encabezados y formato para estadísticas diarias
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

            // Carga alimentos más consumidos en el DataGridView
            dgvTopFoods.DataSource = null;
            dgvTopFoods.DataSource = topFoods;

            // Configuración de encabezados y formato para top alimentos
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