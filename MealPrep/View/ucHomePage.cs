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
        private FoodController foodController;
        private VitaminController vitaminController;
        private User user;

        public ucHomePage(MealController mealController, FoodController foodController, VitaminController vitaminController, User user)
        {
            this.mealController = mealController;
            this.foodController = foodController;
            this.vitaminController = vitaminController;
            this.user = user;
            InitializeComponent();
        }

        private void Initialize()
        {
            List<Meal> meals = mealController.GetAllMeals(user);
        }

        private void newFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAuxiliary addMeal = new FormAuxiliary(new ucAddFood(foodController, vitaminController));
            addMeal.ShowDialog();
        }

        private void addVitaminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAuxiliary addVitamin = new FormAuxiliary(new ucAddVitamin(vitaminController));
            addVitamin.ShowDialog();
        }

        private void addMealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAuxiliary addMeal = new FormAuxiliary(new ucAddMeal(foodController, mealController, user));
            addMeal.ShowDialog();
        }
    }
}
