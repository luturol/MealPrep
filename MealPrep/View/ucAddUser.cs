using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MealPrep.Controller;
using MealPrep.Model;
using MealPrep.Properties;

namespace MealPrep.View
{
    public partial class ucAddUser : UserControl
    {
        private UserController userController;
        private const string CONTROL_TITLE = "New User";

        public ucAddUser(UserController userController)
        {
            this.userController = userController;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(ValidateInputs())
                {
                    userController.AddUser(new User(txtUsername.Text, txtPassword.Text));
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, CONTROL_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private bool ValidateInputs()
        {
            if (txtUsername.Text.Length > 0 && txtPassword.Text.Length > 0)
            {
                return true;
            }
            else
            {
                throw new Exception(Resources.ErrorNeedToFullFillTheUserForm);
            }
        }
    }
}
