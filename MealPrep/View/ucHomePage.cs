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
using MealPrep.Interfaces;

namespace MealPrep.View
{
    public partial class ucHomePage : UserControl, IView
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
            Initialize();
        }

        public void Initialize()
        {
            myProgressBar.Style = ProgressBarStyle.Marquee;
            bgPrepareFullMeals.RunWorkerAsync();
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

        private delegate void MyDelegate();
        private void bgPrepareFullMeals_DoWork(object sender, DoWorkEventArgs e)
        {
            Action showProgressBar = () => myProgressBar.Show();
            myProgressBar.Invoke(showProgressBar);

            List<FullMeal> meals = mealController.GetMealWithFoods(user).OrderByDescending(a => a.Date).ToList();            
            foreach (FullMeal meal in meals)
            {
                if (panelMeal.InvokeRequired)
                {
                    this.Invoke((MyDelegate)delegate
                    {
                        AddToPanelMeal(meal);
                    });
                }                    
            }
        }

        private void bgPrepareFullMeals_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Action hideProgressBar = () => myProgressBar.Hide();
            myProgressBar.Invoke(hideProgressBar);
        }

        private void AddToPanelMeal(FullMeal fullMeal)
        {
            panelMeal.Controls.Add(new ucRowMeal(fullMeal.MealId,
                fullMeal.Date.ToShortDateString(),
                fullMeal.Calories.ToString(),
                fullMeal.Carbs.ToString(),
                fullMeal.Protein.ToString(),
                fullMeal.Fat.ToString()));
        }
    }
}
