namespace MealPrep.View
{
    partial class ucLoginPage
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
            this.panelLogin = new System.Windows.Forms.Panel();
            this.panelAddUser = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.Location = new System.Drawing.Point(0, 3);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(833, 75);
            this.panelLogin.TabIndex = 3;
            // 
            // panelAddUser
            // 
            this.panelAddUser.Location = new System.Drawing.Point(473, 84);
            this.panelAddUser.Name = "panelAddUser";
            this.panelAddUser.Size = new System.Drawing.Size(360, 435);
            this.panelAddUser.TabIndex = 2;
            // 
            // ucLoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panelAddUser);
            this.Name = "ucLoginPage";
            this.Size = new System.Drawing.Size(838, 527);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Panel panelAddUser;
    }
}
