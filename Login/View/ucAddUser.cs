using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MealPrep.Login.Controller;
using MealPrep.Login.Model;

namespace MealPrep.Login.View
{
    public partial class ucAddUser : UserControl
    {
        private UserController userController;
        private const String ERROR_NEED_TO_FULL_FILL_THE_FORM = "Error! Need to full fill the form.";
        private const String CONTROL_TITLE = "New User";

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
                throw new Exception(ERROR_NEED_TO_FULL_FILL_THE_FORM);
            }
        }
    }
}
