namespace Nutrition_App.Views
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            lblTotalMealRecords = new Label();
            lblTotalUsersWithRecords = new Label();
            lblTotalCalories = new Label();
            lblAverageCaloriesPerRecord = new Label();
            lblAverageCaloriesPerUser = new Label();
            lblTotalProtein = new Label();
            lblTotalCarbs = new Label();
            lblTotalFat = new Label();
            dgvDailyStats = new DataGridView();
            lblTopFoodsTitle = new Label();
            dgvTopFoods = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDailyStats).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopFoods).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(324, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(135, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Resumen de estadísticas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 81);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 1;
            label2.Text = "Total registros:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 121);
            label3.Name = "label3";
            label3.Size = new Size(126, 15);
            label3.TabIndex = 2;
            label3.Text = "Usuarios con registros:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 162);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 3;
            label4.Text = "Calorías totales:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 200);
            label5.Name = "label5";
            label5.Size = new Size(126, 15);
            label5.TabIndex = 4;
            label5.Text = "Promedio por registro:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 244);
            label6.Name = "label6";
            label6.Size = new Size(125, 15);
            label6.TabIndex = 5;
            label6.Text = "Promedio por usuario:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 285);
            label7.Name = "label7";
            label7.Size = new Size(81, 15);
            label7.TabIndex = 6;
            label7.Text = "Proteína total:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 326);
            label8.Name = "label8";
            label8.Size = new Size(123, 15);
            label8.TabIndex = 7;
            label8.Text = "Carbohidratos totales:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 365);
            label9.Name = "label9";
            label9.Size = new Size(66, 15);
            label9.TabIndex = 8;
            label9.Text = "Grasa total:";
            // 
            // lblTotalMealRecords
            // 
            lblTotalMealRecords.AutoSize = true;
            lblTotalMealRecords.Location = new Point(196, 81);
            lblTotalMealRecords.Name = "lblTotalMealRecords";
            lblTotalMealRecords.Size = new Size(38, 15);
            lblTotalMealRecords.TabIndex = 9;
            lblTotalMealRecords.Text = "label1";
            // 
            // lblTotalUsersWithRecords
            // 
            lblTotalUsersWithRecords.AutoSize = true;
            lblTotalUsersWithRecords.Location = new Point(196, 121);
            lblTotalUsersWithRecords.Name = "lblTotalUsersWithRecords";
            lblTotalUsersWithRecords.Size = new Size(44, 15);
            lblTotalUsersWithRecords.TabIndex = 10;
            lblTotalUsersWithRecords.Text = "label10";
            // 
            // lblTotalCalories
            // 
            lblTotalCalories.AutoSize = true;
            lblTotalCalories.Location = new Point(196, 162);
            lblTotalCalories.Name = "lblTotalCalories";
            lblTotalCalories.Size = new Size(44, 15);
            lblTotalCalories.TabIndex = 11;
            lblTotalCalories.Text = "label11";
            // 
            // lblAverageCaloriesPerRecord
            // 
            lblAverageCaloriesPerRecord.AutoSize = true;
            lblAverageCaloriesPerRecord.Location = new Point(196, 200);
            lblAverageCaloriesPerRecord.Name = "lblAverageCaloriesPerRecord";
            lblAverageCaloriesPerRecord.Size = new Size(44, 15);
            lblAverageCaloriesPerRecord.TabIndex = 12;
            lblAverageCaloriesPerRecord.Text = "label12";
            // 
            // lblAverageCaloriesPerUser
            // 
            lblAverageCaloriesPerUser.AutoSize = true;
            lblAverageCaloriesPerUser.Location = new Point(196, 244);
            lblAverageCaloriesPerUser.Name = "lblAverageCaloriesPerUser";
            lblAverageCaloriesPerUser.Size = new Size(44, 15);
            lblAverageCaloriesPerUser.TabIndex = 13;
            lblAverageCaloriesPerUser.Text = "label13";
            // 
            // lblTotalProtein
            // 
            lblTotalProtein.AutoSize = true;
            lblTotalProtein.Location = new Point(196, 285);
            lblTotalProtein.Name = "lblTotalProtein";
            lblTotalProtein.Size = new Size(44, 15);
            lblTotalProtein.TabIndex = 14;
            lblTotalProtein.Text = "label14";
            // 
            // lblTotalCarbs
            // 
            lblTotalCarbs.AutoSize = true;
            lblTotalCarbs.Location = new Point(196, 326);
            lblTotalCarbs.Name = "lblTotalCarbs";
            lblTotalCarbs.Size = new Size(44, 15);
            lblTotalCarbs.TabIndex = 15;
            lblTotalCarbs.Text = "label15";
            // 
            // lblTotalFat
            // 
            lblTotalFat.AutoSize = true;
            lblTotalFat.Location = new Point(196, 365);
            lblTotalFat.Name = "lblTotalFat";
            lblTotalFat.Size = new Size(44, 15);
            lblTotalFat.TabIndex = 16;
            lblTotalFat.Text = "label16";
            // 
            // dgvDailyStats
            // 
            dgvDailyStats.AllowUserToAddRows = false;
            dgvDailyStats.AllowUserToDeleteRows = false;
            dgvDailyStats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDailyStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDailyStats.Location = new Point(365, 56);
            dgvDailyStats.Name = "dgvDailyStats";
            dgvDailyStats.ReadOnly = true;
            dgvDailyStats.RowHeadersVisible = false;
            dgvDailyStats.Size = new Size(381, 362);
            dgvDailyStats.TabIndex = 17;
            // 
            // lblTopFoodsTitle
            // 
            lblTopFoodsTitle.AutoSize = true;
            lblTopFoodsTitle.Location = new Point(105, 522);
            lblTopFoodsTitle.Name = "lblTopFoodsTitle";
            lblTopFoodsTitle.Size = new Size(184, 15);
            lblTopFoodsTitle.TabIndex = 18;
            lblTopFoodsTitle.Text = "Top 5 alimentos más consumidos";
            // 
            // dgvTopFoods
            // 
            dgvTopFoods.AllowUserToAddRows = false;
            dgvTopFoods.AllowUserToDeleteRows = false;
            dgvTopFoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTopFoods.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTopFoods.Location = new Point(365, 431);
            dgvTopFoods.Name = "dgvTopFoods";
            dgvTopFoods.ReadOnly = true;
            dgvTopFoods.RowHeadersVisible = false;
            dgvTopFoods.Size = new Size(381, 177);
            dgvTopFoods.TabIndex = 19;
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 612);
            Controls.Add(dgvTopFoods);
            Controls.Add(lblTopFoodsTitle);
            Controls.Add(dgvDailyStats);
            Controls.Add(lblTotalFat);
            Controls.Add(lblTotalCarbs);
            Controls.Add(lblTotalProtein);
            Controls.Add(lblAverageCaloriesPerUser);
            Controls.Add(lblAverageCaloriesPerRecord);
            Controls.Add(lblTotalCalories);
            Controls.Add(lblTotalUsersWithRecords);
            Controls.Add(lblTotalMealRecords);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblTitle);
            Name = "StatisticsForm";
            Text = "Form1";
            Load += StatisticsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDailyStats).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTopFoods).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lblTotalMealRecords;
        private Label lblTotalUsersWithRecords;
        private Label lblTotalCalories;
        private Label lblAverageCaloriesPerRecord;
        private Label lblAverageCaloriesPerUser;
        private Label lblTotalProtein;
        private Label lblTotalCarbs;
        private Label lblTotalFat;
        private DataGridView dgvDailyStats;
        private Label lblTopFoodsTitle;
        private DataGridView dgvTopFoods;
    }
}