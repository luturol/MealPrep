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

namespace MealPrep.View
{
    public partial class ucLoginPage : UserControl
    {
        private UserController userController;
        private MealController mealController;

        public ucLoginPage(UserController userController, MealController mealController)
        {
            this.userController = userController;
            this.mealController = mealController;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            panelLogin.Controls.Add(new ucLogin(userController, mealController));
            panelAddUser.Controls.Add(new ucAddUser(userController));
        }
    }
}
