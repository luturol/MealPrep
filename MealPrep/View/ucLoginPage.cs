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
using MealPrep.Interfaces;

namespace MealPrep.View
{
    public partial class ucLoginPage : UserControl, IView
    {
        private UserController userController;
        private MealController mealController;
        private FoodController foodController;
        private VitaminController vitaminController;

        public ucLoginPage(UserController userController, MealController mealController, 
                           FoodController foodController, VitaminController vitaminController)
        {
            this.userController = userController;
            this.mealController = mealController;
            this.foodController = foodController;
            this.vitaminController = vitaminController;
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            panelLogin.Controls.Add(new ucLogin(userController, mealController, foodController, vitaminController));
            panelAddUser.Controls.Add(new ucAddUser(userController));
        }
    }
}
