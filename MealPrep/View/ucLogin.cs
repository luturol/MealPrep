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
using MealPrep.Properties;

namespace MealPrep.View
{
    public partial class ucLogin : UserControl
    {
        private UserController userController;
        private MealController mealController;
        private FoodController foodController;
        private VitaminController vitaminController;                
        private const string CONTROL_TITLE = "Login";

        public ucLogin(UserController userController, MealController mealController,
                       FoodController foodController, VitaminController vitaminController)
        {
            this.userController = userController;
            this.mealController = mealController;
            this.foodController = foodController;
            this.vitaminController = vitaminController;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateControls())
                {
                    Login(new User(txtUserName.Text, txtPassword.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CONTROL_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                throw new Exception(Resources.ErrorNeedToFullFillLoginAndPassword);
            }
        }

        private void Login(User user)
        {
            if(userController.ValidateLogin(user))
            {
                MessageBox.Show(Resources.WelcomeToMealPrep, CONTROL_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Control parent = GetParentForm();
                parent.Controls.Clear();
                parent.Controls.Add(new ucHomePage(mealController, foodController, vitaminController, user));
            }
            else
            {
                throw new Exception(Resources.ErrorWrongUserOrPassword);
            }
        }

        private Control GetParentForm()
        {
            Control parent = this.Parent;
            Control grandfather = parent.Parent;
            return grandfather;
        }
    }
}
