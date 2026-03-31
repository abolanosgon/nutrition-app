namespace Nutrition_App.Views
{
    partial class UserInfoForm
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
            lblUserName = new Label();
            lblBMI = new Label();
            lblMaintenanceCalories = new Label();
            lblTargetCalories = new Label();
            lblProtein = new Label();
            lblCarbs = new Label();
            lblFats = new Label();
            lblGoal = new Label();
            lblDietType = new Label();
            lblActivityLevel = new Label();
            SuspendLayout();
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(81, 24);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(38, 15);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "label1";
            // 
            // lblBMI
            // 
            lblBMI.AutoSize = true;
            lblBMI.Location = new Point(81, 55);
            lblBMI.Name = "lblBMI";
            lblBMI.Size = new Size(38, 15);
            lblBMI.TabIndex = 1;
            lblBMI.Text = "label1";
            // 
            // lblMaintenanceCalories
            // 
            lblMaintenanceCalories.AutoSize = true;
            lblMaintenanceCalories.Location = new Point(81, 90);
            lblMaintenanceCalories.Name = "lblMaintenanceCalories";
            lblMaintenanceCalories.Size = new Size(38, 15);
            lblMaintenanceCalories.TabIndex = 2;
            lblMaintenanceCalories.Text = "label1";
            // 
            // lblTargetCalories
            // 
            lblTargetCalories.AutoSize = true;
            lblTargetCalories.Location = new Point(81, 122);
            lblTargetCalories.Name = "lblTargetCalories";
            lblTargetCalories.Size = new Size(38, 15);
            lblTargetCalories.TabIndex = 3;
            lblTargetCalories.Text = "label1";
            // 
            // lblProtein
            // 
            lblProtein.AutoSize = true;
            lblProtein.Location = new Point(81, 155);
            lblProtein.Name = "lblProtein";
            lblProtein.Size = new Size(38, 15);
            lblProtein.TabIndex = 4;
            lblProtein.Text = "label1";
            // 
            // lblCarbs
            // 
            lblCarbs.AutoSize = true;
            lblCarbs.Location = new Point(81, 192);
            lblCarbs.Name = "lblCarbs";
            lblCarbs.Size = new Size(38, 15);
            lblCarbs.TabIndex = 5;
            lblCarbs.Text = "label1";
            // 
            // lblFats
            // 
            lblFats.AutoSize = true;
            lblFats.Location = new Point(81, 228);
            lblFats.Name = "lblFats";
            lblFats.Size = new Size(38, 15);
            lblFats.TabIndex = 6;
            lblFats.Text = "label1";
            // 
            // lblGoal
            // 
            lblGoal.AutoSize = true;
            lblGoal.Location = new Point(81, 267);
            lblGoal.Name = "lblGoal";
            lblGoal.Size = new Size(38, 15);
            lblGoal.TabIndex = 7;
            lblGoal.Text = "label1";
            // 
            // lblDietType
            // 
            lblDietType.AutoSize = true;
            lblDietType.Location = new Point(81, 300);
            lblDietType.Name = "lblDietType";
            lblDietType.Size = new Size(38, 15);
            lblDietType.TabIndex = 8;
            lblDietType.Text = "label1";
            // 
            // lblActivityLevel
            // 
            lblActivityLevel.AutoSize = true;
            lblActivityLevel.Location = new Point(81, 333);
            lblActivityLevel.Name = "lblActivityLevel";
            lblActivityLevel.Size = new Size(38, 15);
            lblActivityLevel.TabIndex = 9;
            lblActivityLevel.Text = "label1";
            // 
            // UserInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(590, 450);
            Controls.Add(lblActivityLevel);
            Controls.Add(lblDietType);
            Controls.Add(lblGoal);
            Controls.Add(lblFats);
            Controls.Add(lblCarbs);
            Controls.Add(lblProtein);
            Controls.Add(lblTargetCalories);
            Controls.Add(lblMaintenanceCalories);
            Controls.Add(lblBMI);
            Controls.Add(lblUserName);
            Name = "UserInfoForm";
            Text = "Form1";
            Load += UserInfoForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUserName;
        private Label lblBMI;
        private Label lblMaintenanceCalories;
        private Label lblTargetCalories;
        private Label lblProtein;
        private Label lblCarbs;
        private Label lblFats;
        private Label lblGoal;
        private Label lblDietType;
        private Label lblActivityLevel;
    }
}