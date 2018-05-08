﻿using System;
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

namespace MealPrep.View
{
    public partial class ucLogin : UserControl
    {
        private UserController userController;
        private const String ERROR_NEED_TO_FULL_FILL_THE_FORM = "Error! Need to full fill the form.";
        public ucLogin(UserController userController)
        {
            this.userController = userController;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {
                    userController.UserExists(new User(txtUserName.Text, txtPassword.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidateControls()
        {
            if (txtUserName.Text.Length > 0 && txtPassword.Text.Length > 0)
            {
                return true;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
