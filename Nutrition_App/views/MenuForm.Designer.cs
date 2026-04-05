using Nutrition_App.Controllers;
using Nutrition_App.Models;
using Nutrition_App.Repositories;

namespace Nutrition_App.Views
{
    public partial class MenuForm : Form
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
            lblMenuName = new Label();
            lblGoal = new Label();
            lblDietType = new Label();
            dgvMenu = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            SuspendLayout();
            // 
            // lblMenuName
            // 
            lblMenuName.AutoSize = true;
            lblMenuName.Location = new Point(27, 115);
            lblMenuName.Name = "lblMenuName";
            lblMenuName.Size = new Size(38, 15);
            lblMenuName.TabIndex = 0;
            lblMenuName.Text = "label1";
            // 
            // lblGoal
            // 
            lblGoal.AutoSize = true;
            lblGoal.Location = new Point(27, 166);
            lblGoal.Name = "lblGoal";
            lblGoal.Size = new Size(38, 15);
            lblGoal.TabIndex = 1;
            lblGoal.Text = "label1";
            // 
            // lblDietType
            // 
            lblDietType.AutoSize = true;
            lblDietType.Location = new Point(27, 211);
            lblDietType.Name = "lblDietType";
            lblDietType.Size = new Size(38, 15);
            lblDietType.TabIndex = 2;
            lblDietType.Text = "label1";
            // 
            // dgvMenu
            // 
            dgvMenu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMenu.Location = new Point(185, 53);
            dgvMenu.Name = "dgvMenu";
            dgvMenu.Size = new Size(722, 345);
            dgvMenu.TabIndex = 4;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 462);
            Controls.Add(dgvMenu);
            Controls.Add(lblDietType);
            Controls.Add(lblGoal);
            Controls.Add(lblMenuName);
            Name = "MenuForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMenuName;
        private Label lblGoal;
        private Label lblDietType;
        private DataGridView dgvMenu;
    }
}