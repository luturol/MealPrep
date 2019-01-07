using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MealPrep.Model;
using MealPrep.Useful;

namespace MealPrep.View
{
    public partial class ucFullMeal : UserControl
    {
        private FullMeal fullMeal;

        #region Grid config
        private const string COLUMN_FOOD_AMOUNT = "Amount";
        private const string COLUMN_FOOD_CALORIES = "Calories";
        private const string COLUMN_FOOD_CARBS = "Carbs";
        private const string COLUMN_FOOD_FAT = "Fat";
        private const string COLUMN_FOOD_ID = "Food ID";
        private const string COLUMN_FOOD_NAME = "Food";
        private const string COLUMN_FOOD_PROTEIN = "Protein";
        #endregion

        public ucFullMeal(FullMeal fullMeal)
        {
            this.fullMeal = fullMeal;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {            
            txtAmount.Text = Math.Round(fullMeal.Amount, 2).ToString();
            txtCalories.Text = Math.Round(fullMeal.Calories, 2).ToString();
            txtCarbs.Text = Math.Round(fullMeal.Carbs, 2).ToString();
            txtFat.Text = Math.Round(fullMeal.Fat, 2).ToString();
            txtProtein.Text = Math.Round(fullMeal.Protein, 2).ToString();

            gcFoods.DataSource = PopulateTableMealFoods(fullMeal.Meal.MealFoods);
        }

        private DataTable PopulateTableMealFoods(List<MealFood> mealFoods)
        {
            DataTable table = CreateLayoutTableMealFoods();

            foreach(MealFood mealFood in mealFoods)
            {
                double calories = Math.Round(UsefulAlgorithms.By3Rule(mealFood.Amount, mealFood.Food.Calories, mealFood.Food.Amount), 2);
                double carbs = Math.Round(UsefulAlgorithms.By3Rule(mealFood.Amount, mealFood.Food.Carbs, mealFood.Food.Amount), 2);
                double protein = Math.Round(UsefulAlgorithms.By3Rule(mealFood.Amount, mealFood.Food.Protein, mealFood.Food.Amount), 2);
                double fat = Math.Round(UsefulAlgorithms.By3Rule(mealFood.Amount, mealFood.Food.Fat, mealFood.Food.Amount), 2);

                table.Rows.Add(mealFood.Food.FoodID, mealFood.Food.Name, mealFood.Amount, calories, carbs, protein, fat);
            }

            return table;
        }

        private DataTable CreateLayoutTableMealFoods()
        {
            DataTable table = new DataTable();

            table.Columns.AddRange(new DataColumn[7] {
                        new DataColumn(COLUMN_FOOD_ID, typeof(string)),
                        new DataColumn(COLUMN_FOOD_NAME, typeof(string)),
                        new DataColumn(COLUMN_FOOD_AMOUNT, typeof(string)),
                        new DataColumn(COLUMN_FOOD_CALORIES, typeof(string)),
                        new DataColumn(COLUMN_FOOD_CARBS, typeof(string)),
                        new DataColumn(COLUMN_FOOD_PROTEIN, typeof(string)),
                        new DataColumn(COLUMN_FOOD_FAT, typeof(string))
            });

            return table;
        }

    }
}
