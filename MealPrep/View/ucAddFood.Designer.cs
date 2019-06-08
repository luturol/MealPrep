namespace MealPrep.View
{
    partial class ucAddFood
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtFoodName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtCarbs = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProtein = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbWeightVitamin = new System.Windows.Forms.ComboBox();
            this.txtAmountVitamin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbVitamins = new System.Windows.Forms.ComboBox();
            this.btnAddVitamin = new System.Windows.Forms.Button();
            this.gcVitamins = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCalories = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcVitamins)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(142, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Food";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // txtFoodName
            // 
            this.txtFoodName.Location = new System.Drawing.Point(57, 27);
            this.txtFoodName.Name = "txtFoodName";
            this.txtFoodName.Size = new System.Drawing.Size(270, 20);
            this.txtFoodName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(57, 66);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(88, 20);
            this.txtAmount.TabIndex = 4;
            // 
            // txtCarbs
            // 
            this.txtCarbs.Location = new System.Drawing.Point(57, 92);
            this.txtCarbs.Name = "txtCarbs";
            this.txtCarbs.Size = new System.Drawing.Size(88, 20);
            this.txtCarbs.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Carbs:";
            // 
            // txtProtein
            // 
            this.txtProtein.Location = new System.Drawing.Point(213, 92);
            this.txtProtein.Name = "txtProtein";
            this.txtProtein.Size = new System.Drawing.Size(88, 20);
            this.txtProtein.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Protein:";
            // 
            // txtFat
            // 
            this.txtFat.Location = new System.Drawing.Point(57, 118);
            this.txtFat.Name = "txtFat";
            this.txtFat.Size = new System.Drawing.Size(88, 20);
            this.txtFat.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Fat:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(132, 357);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtCarbs);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFat);
            this.groupBox1.Controls.Add(this.txtFoodName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtProtein);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCalories);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(15, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 386);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Food Properties";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbWeightVitamin);
            this.groupBox2.Controls.Add(this.txtAmountVitamin);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbVitamins);
            this.groupBox2.Controls.Add(this.btnAddVitamin);
            this.groupBox2.Controls.Add(this.gcVitamins);
            this.groupBox2.Location = new System.Drawing.Point(6, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 194);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vitamins";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(207, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Weight:";
            // 
            // cbWeightVitamin
            // 
            this.cbWeightVitamin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWeightVitamin.FormattingEnabled = true;
            this.cbWeightVitamin.Location = new System.Drawing.Point(257, 19);
            this.cbWeightVitamin.Name = "cbWeightVitamin";
            this.cbWeightVitamin.Size = new System.Drawing.Size(65, 21);
            this.cbWeightVitamin.TabIndex = 21;
            // 
            // txtAmountVitamin
            // 
            this.txtAmountVitamin.Location = new System.Drawing.Point(80, 46);
            this.txtAmountVitamin.Name = "txtAmountVitamin";
            this.txtAmountVitamin.Size = new System.Drawing.Size(121, 20);
            this.txtAmountVitamin.TabIndex = 20;
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
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Vitamins:";
            // 
            // cbVitamins
            // 
            this.cbVitamins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVitamins.FormattingEnabled = true;
            this.cbVitamins.Location = new System.Drawing.Point(80, 21);
            this.cbVitamins.Name = "cbVitamins";
            this.cbVitamins.Size = new System.Drawing.Size(121, 21);
            this.cbVitamins.TabIndex = 17;
            // 
            // btnAddVitamin
            // 
            this.btnAddVitamin.Location = new System.Drawing.Point(210, 43);
            this.btnAddVitamin.Name = "btnAddVitamin";
            this.btnAddVitamin.Size = new System.Drawing.Size(75, 23);
            this.btnAddVitamin.TabIndex = 16;
            this.btnAddVitamin.Text = "Add Vitamin";
            this.btnAddVitamin.UseVisualStyleBackColor = true;
            this.btnAddVitamin.Click += new System.EventHandler(this.btnAddVitamin_Click);
            // 
            // gcVitamins
            // 
            this.gcVitamins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcVitamins.Location = new System.Drawing.Point(6, 72);
            this.gcVitamins.Name = "gcVitamins";
            this.gcVitamins.Size = new System.Drawing.Size(342, 116);
            this.gcVitamins.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Calories*:";
            // 
            // txtCalories
            // 
            this.txtCalories.Location = new System.Drawing.Point(213, 66);
            this.txtCalories.Name = "txtCalories";
            this.txtCalories.Size = new System.Drawing.Size(88, 20);
            this.txtCalories.TabIndex = 6;
            // 
            // ucAddFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "ucAddFood";
            this.Size = new System.Drawing.Size(406, 472);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcVitamins)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFoodName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtCarbs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProtein;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gcVitamins;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbVitamins;
        private System.Windows.Forms.Button btnAddVitamin;
        private System.Windows.Forms.TextBox txtAmountVitamin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbWeightVitamin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCalories;
    }
}
