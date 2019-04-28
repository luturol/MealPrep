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
using MealPrep.Meal.Controller;
using MealPrep.Model;
using MealPrep.Utils;
using MealPrep.View;
using MealPrep.Food.Controller;
using MealPrep.Food.View;

namespace MealPrep.Meal.View
{
    public partial class ucHomePage : UserControl
    {
        private User user;
        private MealController mealController;
        private FoodController foodController;
        private VitaminController vitaminController;

        public ucHomePage(User user)
        {
            this.user = user;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            List<FullMeal> meals = mealController.GetMealWithFoods(user).OrderByDescending(a => a.Date).ToList();
            foreach(FullMeal meal in meals)
            {
                panelMeal.Controls.Add(new ucRowMeal(meal.MealId, meal.Date.ToShortDateString(), meal.Calories.ToString(), meal.Carbs.ToString(), meal.Protein.ToString(), meal.Fat.ToString()));
            }
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
