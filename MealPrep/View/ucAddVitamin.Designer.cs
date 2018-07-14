namespace MealPrep.View
{
    partial class ucAddVitamin
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
            this.txtVitaminName = new System.Windows.Forms.TextBox();
            this.lblVitaminLabelText = new System.Windows.Forms.Label();
            this.lblVitaminIDValue = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(103, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Vitamin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vitamin Name:";
            // 
            // txtVitaminName
            // 
            this.txtVitaminName.Location = new System.Drawing.Point(108, 110);
            this.txtVitaminName.Name = "txtVitaminName";
            this.txtVitaminName.Size = new System.Drawing.Size(188, 20);
            this.txtVitaminName.TabIndex = 2;
            // 
            // lblVitaminLabelText
            // 
            this.lblVitaminLabelText.AutoSize = true;
            this.lblVitaminLabelText.Location = new System.Drawing.Point(39, 78);
            this.lblVitaminLabelText.Name = "lblVitaminLabelText";
            this.lblVitaminLabelText.Size = new System.Drawing.Size(58, 13);
            this.lblVitaminLabelText.TabIndex = 3;
            this.lblVitaminLabelText.Text = "Vitamin ID:";
            // 
            // lblVitaminIDValue
            // 
            this.lblVitaminIDValue.AutoSize = true;
            this.lblVitaminIDValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVitaminIDValue.Location = new System.Drawing.Point(105, 78);
            this.lblVitaminIDValue.Name = "lblVitaminIDValue";
            this.lblVitaminIDValue.Size = new System.Drawing.Size(106, 13);
            this.lblVitaminIDValue.TabIndex = 4;
            this.lblVitaminIDValue.Text = "lblVitaminIDValue";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(123, 172);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucAddVitamin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblVitaminIDValue);
            this.Controls.Add(this.lblVitaminLabelText);
            this.Controls.Add(this.txtVitaminName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucAddVitamin";
            this.Size = new System.Drawing.Size(337, 352);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVitaminName;
        private System.Windows.Forms.Label lblVitaminLabelText;
        private System.Windows.Forms.Label lblVitaminIDValue;
        private System.Windows.Forms.Button btnSave;
    }
}
