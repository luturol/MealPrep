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
            this.panelMeals = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.foodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFoodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vitaminsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVitaminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMeals
            // 
            this.panelMeals.Location = new System.Drawing.Point(35, 93);
            this.panelMeals.Name = "panelMeals";
            this.panelMeals.Size = new System.Drawing.Size(714, 417);
            this.panelMeals.TabIndex = 0;
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
            this.newFoodToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.addVitaminToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.addMealToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addMealToolStripMenuItem.Text = "Add Meal";
            this.addMealToolStripMenuItem.Click += new System.EventHandler(this.addMealToolStripMenuItem_Click);
            // 
            // ucHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelMeals);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ucHomePage";
            this.Size = new System.Drawing.Size(787, 541);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMeals;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem foodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFoodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vitaminsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVitaminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mealToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMealToolStripMenuItem;
    }
}
