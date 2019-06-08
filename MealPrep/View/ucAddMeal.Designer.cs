namespace MealPrep.View
{
    partial class ucAddMeal
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.gpFood = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbWeightFood = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveMeal = new System.Windows.Forms.Button();
            this.gcFoods = new System.Windows.Forms.DataGridView();
            this.gpFood.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFoods)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(148, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Meal";
            // 
            // gpFood
            // 
            this.gpFood.Controls.Add(this.gcFoods);
            this.gpFood.Controls.Add(this.label10);
            this.gpFood.Controls.Add(this.cbWeightFood);
            this.gpFood.Controls.Add(this.txtAmount);
            this.gpFood.Controls.Add(this.label9);
            this.gpFood.Controls.Add(this.label8);
            this.gpFood.Controls.Add(this.cbFood);
            this.gpFood.Controls.Add(this.btnAddFood);
            this.gpFood.Location = new System.Drawing.Point(3, 89);
            this.gpFood.Name = "gpFood";
            this.gpFood.Size = new System.Drawing.Size(414, 194);
            this.gpFood.TabIndex = 17;
            this.gpFood.TabStop = false;
            this.gpFood.Text = "Foods";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(246, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Weight:";
            // 
            // cbWeightFood
            // 
            this.cbWeightFood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWeightFood.FormattingEnabled = true;
            this.cbWeightFood.Location = new System.Drawing.Point(296, 21);
            this.cbWeightFood.Name = "cbWeightFood";
            this.cbWeightFood.Size = new System.Drawing.Size(65, 21);
            this.cbWeightFood.TabIndex = 21;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(80, 46);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(121, 20);
            this.txtAmount.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Amount:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Food:";
            // 
            // cbFood
            // 
            this.cbFood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(80, 21);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(121, 21);
            this.cbFood.TabIndex = 17;
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(286, 44);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(75, 23);
            this.btnAddFood.TabIndex = 16;
            this.btnAddFood.Text = "Add Food";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(101, 63);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(79, 20);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Meal date:";
            // 
            // btnSaveMeal
            // 
            this.btnSaveMeal.Location = new System.Drawing.Point(153, 289);
            this.btnSaveMeal.Name = "btnSaveMeal";
            this.btnSaveMeal.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMeal.TabIndex = 20;
            this.btnSaveMeal.Text = "Save Meal";
            this.btnSaveMeal.UseVisualStyleBackColor = true;
            this.btnSaveMeal.Click += new System.EventHandler(this.btnSaveMeal_Click);
            // 
            // gcFoods
            // 
            this.gcFoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcFoods.Location = new System.Drawing.Point(6, 78);
            this.gcFoods.Name = "gcFoods";
            this.gcFoods.Size = new System.Drawing.Size(402, 116);
            this.gcFoods.TabIndex = 23;
            // 
            // ucAddMeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSaveMeal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.gpFood);
            this.Controls.Add(this.label1);
            this.Name = "ucAddMeal";
            this.Size = new System.Drawing.Size(420, 338);
            this.gpFood.ResumeLayout(false);
            this.gpFood.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFoods)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpFood;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbWeightFood;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveMeal;
        private System.Windows.Forms.DataGridView gcFoods;
    }
}
