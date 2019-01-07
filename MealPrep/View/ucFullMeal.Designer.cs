namespace MealPrep.View
{
    partial class ucFullMeal
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.gcFoods = new System.Windows.Forms.DataGridView();
            this.gpMealMacros = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToday = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtCarbs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFat = new System.Windows.Forms.TextBox();
            this.txtCalories = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProtein = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gcFoods)).BeginInit();
            this.gpMealMacros.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitle.Location = new System.Drawing.Point(149, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(129, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Full Meal #";
            // 
            // gcFoods
            // 
            this.gcFoods.AllowUserToAddRows = false;
            this.gcFoods.AllowUserToDeleteRows = false;
            this.gcFoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcFoods.Location = new System.Drawing.Point(16, 218);
            this.gcFoods.Name = "gcFoods";
            this.gcFoods.Size = new System.Drawing.Size(402, 176);
            this.gcFoods.TabIndex = 24;
            // 
            // gpMealMacros
            // 
            this.gpMealMacros.Controls.Add(this.lblDate);
            this.gpMealMacros.Controls.Add(this.dtToday);
            this.gpMealMacros.Controls.Add(this.txtAmount);
            this.gpMealMacros.Controls.Add(this.txtCarbs);
            this.gpMealMacros.Controls.Add(this.label5);
            this.gpMealMacros.Controls.Add(this.txtFat);
            this.gpMealMacros.Controls.Add(this.txtCalories);
            this.gpMealMacros.Controls.Add(this.label7);
            this.gpMealMacros.Controls.Add(this.label4);
            this.gpMealMacros.Controls.Add(this.label3);
            this.gpMealMacros.Controls.Add(this.label6);
            this.gpMealMacros.Controls.Add(this.txtProtein);
            this.gpMealMacros.Location = new System.Drawing.Point(52, 75);
            this.gpMealMacros.Name = "gpMealMacros";
            this.gpMealMacros.Size = new System.Drawing.Size(308, 137);
            this.gpMealMacros.TabIndex = 25;
            this.gpMealMacros.TabStop = false;
            this.gpMealMacros.Text = "Meal macros";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(19, 26);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 24;
            this.lblDate.Text = "Date:";
            // 
            // dtToday
            // 
            this.dtToday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtToday.Location = new System.Drawing.Point(58, 22);
            this.dtToday.Name = "dtToday";
            this.dtToday.Size = new System.Drawing.Size(88, 20);
            this.dtToday.TabIndex = 23;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(58, 48);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(88, 20);
            this.txtAmount.TabIndex = 14;
            // 
            // txtCarbs
            // 
            this.txtCarbs.Location = new System.Drawing.Point(58, 74);
            this.txtCarbs.Name = "txtCarbs";
            this.txtCarbs.Size = new System.Drawing.Size(88, 20);
            this.txtCarbs.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Carbs:";
            // 
            // txtFat
            // 
            this.txtFat.Location = new System.Drawing.Point(58, 100);
            this.txtFat.Name = "txtFat";
            this.txtFat.Size = new System.Drawing.Size(88, 20);
            this.txtFat.TabIndex = 22;
            // 
            // txtCalories
            // 
            this.txtCalories.Location = new System.Drawing.Point(214, 48);
            this.txtCalories.Name = "txtCalories";
            this.txtCalories.Size = new System.Drawing.Size(88, 20);
            this.txtCalories.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Fat:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Calories*:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Amount:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Protein:";
            // 
            // txtProtein
            // 
            this.txtProtein.Location = new System.Drawing.Point(214, 74);
            this.txtProtein.Name = "txtProtein";
            this.txtProtein.Size = new System.Drawing.Size(88, 20);
            this.txtProtein.TabIndex = 20;
            // 
            // ucFullMeal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpMealMacros);
            this.Controls.Add(this.gcFoods);
            this.Controls.Add(this.lblTitle);
            this.Name = "ucFullMeal";
            this.Size = new System.Drawing.Size(435, 441);
            ((System.ComponentModel.ISupportInitialize)(this.gcFoods)).EndInit();
            this.gpMealMacros.ResumeLayout(false);
            this.gpMealMacros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView gcFoods;
        private System.Windows.Forms.GroupBox gpMealMacros;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToday;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtCarbs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFat;
        private System.Windows.Forms.TextBox txtCalories;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProtein;
    }
}
