namespace MealPrep.View
{
    partial class ucHomePage
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.foodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFoodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vitaminsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVitaminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCarbs = new System.Windows.Forms.TextBox();
            this.txtFat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProtein = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCalories = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gpTodayMacros = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToday = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.gcFullMeals = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.gpTodayMacros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFullMeals)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(243, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "MealPrep Home Page";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.foodToolStripMenuItem,
            this.vitaminsToolStripMenuItem,
            this.mealToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(787, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // foodToolStripMenuItem
            // 
            this.foodToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFoodToolStripMenuItem});
            this.foodToolStripMenuItem.Name = "foodToolStripMenuItem";
            this.foodToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.foodToolStripMenuItem.Text = "Food";
            // 
            // newFoodToolStripMenuItem
            // 
            this.newFoodToolStripMenuItem.Name = "newFoodToolStripMenuItem";
            this.newFoodToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.newFoodToolStripMenuItem.Text = "New Food";
            this.newFoodToolStripMenuItem.Click += new System.EventHandler(this.newFoodToolStripMenuItem_Click);
            // 
            // vitaminsToolStripMenuItem
            // 
            this.vitaminsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVitaminToolStripMenuItem});
            this.vitaminsToolStripMenuItem.Name = "vitaminsToolStripMenuItem";
            this.vitaminsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.vitaminsToolStripMenuItem.Text = "Vitamins";
            // 
            // addVitaminToolStripMenuItem
            // 
            this.addVitaminToolStripMenuItem.Name = "addVitaminToolStripMenuItem";
            this.addVitaminToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.addVitaminToolStripMenuItem.Text = "Add Vitamin";
            this.addVitaminToolStripMenuItem.Click += new System.EventHandler(this.addVitaminToolStripMenuItem_Click);
            // 
            // mealToolStripMenuItem
            // 
            this.mealToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMealToolStripMenuItem});
            this.mealToolStripMenuItem.Name = "mealToolStripMenuItem";
            this.mealToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.mealToolStripMenuItem.Text = "Meal";
            // 
            // addMealToolStripMenuItem
            // 
            this.addMealToolStripMenuItem.Name = "addMealToolStripMenuItem";
            this.addMealToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.addMealToolStripMenuItem.Text = "Add Meal";
            this.addMealToolStripMenuItem.Click += new System.EventHandler(this.addMealToolStripMenuItem_Click);
            // 
            // txtCarbs
            // 
            this.txtCarbs.Location = new System.Drawing.Point(58, 74);
            this.txtCarbs.Name = "txtCarbs";
            this.txtCarbs.Size = new System.Drawing.Size(88, 20);
            this.txtCarbs.TabIndex = 18;
            // 
            // txtFat
            // 
            this.txtFat.Location = new System.Drawing.Point(58, 100);
            this.txtFat.Name = "txtFat";
            this.txtFat.Size = new System.Drawing.Size(88, 20);
            this.txtFat.TabIndex = 22;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Amount:";
            // 
            // txtProtein
            // 
            this.txtProtein.Location = new System.Drawing.Point(214, 74);
            this.txtProtein.Name = "txtProtein";
            this.txtProtein.Size = new System.Drawing.Size(88, 20);
            this.txtProtein.TabIndex = 20;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Calories*:";
            // 
            // txtCalories
            // 
            this.txtCalories.Location = new System.Drawing.Point(214, 48);
            this.txtCalories.Name = "txtCalories";
            this.txtCalories.Size = new System.Drawing.Size(88, 20);
            this.txtCalories.TabIndex = 16;
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
            // gpTodayMacros
            // 
            this.gpTodayMacros.Controls.Add(this.lblDate);
            this.gpTodayMacros.Controls.Add(this.dtToday);
            this.gpTodayMacros.Controls.Add(this.txtAmount);
            this.gpTodayMacros.Controls.Add(this.txtCarbs);
            this.gpTodayMacros.Controls.Add(this.label5);
            this.gpTodayMacros.Controls.Add(this.txtFat);
            this.gpTodayMacros.Controls.Add(this.txtCalories);
            this.gpTodayMacros.Controls.Add(this.label7);
            this.gpTodayMacros.Controls.Add(this.label4);
            this.gpTodayMacros.Controls.Add(this.label3);
            this.gpTodayMacros.Controls.Add(this.label6);
            this.gpTodayMacros.Controls.Add(this.txtProtein);
            this.gpTodayMacros.Location = new System.Drawing.Point(231, 77);
            this.gpTodayMacros.Name = "gpTodayMacros";
            this.gpTodayMacros.Size = new System.Drawing.Size(308, 137);
            this.gpTodayMacros.TabIndex = 23;
            this.gpTodayMacros.TabStop = false;
            this.gpTodayMacros.Text = "Today macros";
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
            this.dtToday.ValueChanged += new System.EventHandler(this.dtToday_ValueChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(58, 48);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(88, 20);
            this.txtAmount.TabIndex = 14;
            // 
            // gcFullMeals
            // 
            this.gcFullMeals.AllowUserToAddRows = false;
            this.gcFullMeals.AllowUserToDeleteRows = false;
            this.gcFullMeals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcFullMeals.Location = new System.Drawing.Point(97, 220);
            this.gcFullMeals.Name = "gcFullMeals";
            this.gcFullMeals.Size = new System.Drawing.Size(636, 204);
            this.gcFullMeals.TabIndex = 24;
            this.gcFullMeals.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gcFullMeals_CellClick);
            this.gcFullMeals.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gcFullMeals_CellContentDoubleClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::MealPrep.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(179, 32);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(43, 39);
            this.btnRefresh.TabIndex = 25;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ucHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.gcFullMeals);
            this.Controls.Add(this.gpTodayMacros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ucHomePage";
            this.Size = new System.Drawing.Size(787, 541);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gpTodayMacros.ResumeLayout(false);
            this.gpTodayMacros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcFullMeals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem foodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFoodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vitaminsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVitaminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mealToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMealToolStripMenuItem;
        private System.Windows.Forms.TextBox txtCarbs;
        private System.Windows.Forms.TextBox txtFat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProtein;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCalories;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gpTodayMacros;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToday;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DataGridView gcFullMeals;
        private System.Windows.Forms.Button btnRefresh;
    }
}
