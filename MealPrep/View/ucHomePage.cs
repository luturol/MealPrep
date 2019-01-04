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
            Initialize();
        }

        private void Initialize()
        {
            LoadMealsByChoosenDay(dtToday.Value);
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

        private void LoadMealsByChoosenDay(DateTime mealDate)
        {
            List<FullMeal> fullMeals = mealController.GetMealWithFoods(user)
                                                    .Where(e => e.Date.ToString("dd/MM/yyyy") == mealDate.ToString("dd/MM/yyyy"))
                                                    .ToList();
            txtAmount.Text = Math.Round(fullMeals.Sum(e => e.Amount), 2).ToString();
            txtCalories.Text = Math.Round(fullMeals.Sum(e => e.Calories), 2).ToString();
            txtCarbs.Text = Math.Round(fullMeals.Sum(e => e.Carbs), 2).ToString();
            txtFat.Text = Math.Round(fullMeals.Sum(e => e.Fat), 2).ToString();
            txtProtein.Text = Math.Round(fullMeals.Sum(e => e.Protein), 2).ToString();

            gcFullMeals.DataSource = PopulateTableFullMeal(fullMeals);
        }

        private DataTable CreateTableForFullMeals()
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[6] {
                        new DataColumn("Meal ID", typeof(string)),
                        new DataColumn("Amount", typeof(string)),
                        new DataColumn("Calories", typeof(string)),
                        new DataColumn("Carbs", typeof(string)),
                        new DataColumn("Protein", typeof(string)),
                        new DataColumn("Fat", typeof(string))
            });
            return table;
        }

        private DataTable PopulateTableFullMeal(List<FullMeal> fullMeals)
        {
            DataTable tableFullMeal = CreateTableForFullMeals();

            foreach (FullMeal fullMeal in fullMeals)
            {
                tableFullMeal.Rows.Add(fullMeal.MealId, Math.Round(fullMeal.Amount, 2), Math.Round(fullMeal.Calories, 2), Math.Round(fullMeal.Carbs, 2), Math.Round(fullMeal.Protein, 2), Math.Round(fullMeal.Fat, 2));
            }

            return tableFullMeal;
        }

        private void dtToday_ValueChanged(object sender, EventArgs e)
        {
            LoadMealsByChoosenDay(dtToday.Value);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadMealsByChoosenDay(dtToday.Value);
        }
    }
}
