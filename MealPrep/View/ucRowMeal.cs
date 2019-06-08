using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MealPrep.Interfaces;

namespace MealPrep.View
{
    public partial class ucRowMeal : UserControl, IView
    {
        private int id;
        private string date;
        private string calories;
        private string carbs;
        private string protein;
        private string fat;

        public ucRowMeal(int id, string date, string calories, string carbs, string protein, string fat)
        {
            this.id = id;
            this.date = date;
            this.calories = calories;
            this.carbs = carbs;
            this.protein = protein;
            this.fat = fat;
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            lblMealID.Text = id.ToString();
            lblDateMeal.Text = date;
            lblCaloriesMeal.Text = calories;
            lblCarbsMeal.Text = carbs;
            lblProteinMeal.Text = protein;
            lblFatMeal.Text = fat;
        }
    }
}
