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

namespace MealPrep.View
{
    public partial class ucHomePage : UserControl
    {
        private MealController mealController;
        private User user;

        public ucHomePage(MealController mealController, User user)
        {
            this.mealController = mealController;
            this.user = user;
            InitializeComponent();
        }

        private void Initialize()
        {
            List<Meal> meals = mealController.GetAllMeals(user);
        }
    }
}
