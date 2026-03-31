namespace Nutrition_App.Views
{
    partial class EditFoodForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            txtFoodName = new TextBox();
            txtCategory = new TextBox();
            label2 = new Label();
            txtCalories = new TextBox();
            label3 = new Label();
            txtProtein = new TextBox();
            label4 = new Label();
            txtCarbohydrates = new TextBox();
            label5 = new Label();
            txtFat = new TextBox();
            label6 = new Label();
            txtPortionSize = new TextBox();
            label7 = new Label();
            btnSaveChanges = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 57);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtFoodName
            // 
            txtFoodName.Location = new Point(152, 54);
            txtFoodName.Name = "txtFoodName";
            txtFoodName.Size = new Size(100, 23);
            txtFoodName.TabIndex = 1;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(152, 83);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(100, 23);
            txtCategory.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 86);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "Categoria";
            // 
            // txtCalories
            // 
            txtCalories.Location = new Point(152, 112);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(100, 23);
            txtCalories.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 115);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 4;
            label3.Text = "Calorias";
            // 
            // txtProtein
            // 
            txtProtein.Location = new Point(152, 141);
            txtProtein.Name = "txtProtein";
            txtProtein.Size = new Size(100, 23);
            txtProtein.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 144);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 6;
            label4.Text = "Proteina";
            // 
            // txtCarbohydrates
            // 
            txtCarbohydrates.Location = new Point(152, 170);
            txtCarbohydrates.Name = "txtCarbohydrates";
            txtCarbohydrates.Size = new Size(100, 23);
            txtCarbohydrates.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(55, 173);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 8;
            label5.Text = "Carbohidratos";
            // 
            // txtFat
            // 
            txtFat.Location = new Point(152, 199);
            txtFat.Name = "txtFat";
            txtFat.Size = new Size(100, 23);
            txtFat.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(55, 202);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 10;
            label6.Text = "Grasa";
            // 
            // txtPortionSize
            // 
            txtPortionSize.Location = new Point(152, 228);
            txtPortionSize.Name = "txtPortionSize";
            txtPortionSize.Size = new Size(100, 23);
            txtPortionSize.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(55, 231);
            label7.Name = "label7";
            label7.Size = new Size(48, 15);
            label7.TabIndex = 12;
            label7.Text = "Porcion";
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(62, 283);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(190, 30);
            btnSaveChanges.TabIndex = 15;
            btnSaveChanges.Text = "Guardar cambios";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // EditFoodForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(567, 531);
            Controls.Add(btnSaveChanges);
            Controls.Add(txtPortionSize);
            Controls.Add(label7);
            Controls.Add(txtFat);
            Controls.Add(label6);
            Controls.Add(txtCarbohydrates);
            Controls.Add(label5);
            Controls.Add(txtProtein);
            Controls.Add(label4);
            Controls.Add(txtCalories);
            Controls.Add(label3);
            Controls.Add(txtCategory);
            Controls.Add(label2);
            Controls.Add(txtFoodName);
            Controls.Add(label1);
            Name = "EditFoodForm";
            Text = "Editar alimento";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtFoodName;
        private TextBox txtCategory;
        private Label label2;
        private TextBox txtCalories;
        private Label label3;
        private TextBox txtProtein;
        private Label label4;
        private TextBox txtCarbohydrates;
        private Label label5;
        private TextBox txtFat;
        private Label label6;
        private TextBox txtPortionSize;
        private Label label7;
        private Button btnSaveChanges;
    }
}