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
using MealPrep.Properties;

namespace MealPrep.View
{
    public partial class ucAddMeal : UserControl, IView
    {
        private FoodController foodController;
        private MealController mealController;
        private User user;        

        private const string COLUMN_FOOD_ID = "ID";
        private const string COLUMN_FOOD_NAME = "NAME";
        private const string COLUMN_FOOD_AMOUNT = "AMOUNT";
        private const string COLUMN_FOOD_WEIGHT = "WEIGHT";

        public ucAddMeal(FoodController foodController, MealController mealController, User user)
        {
            this.foodController = foodController;
            this.mealController = mealController;
            this.user = user;
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            InitializeComboBox();
            gcFoods.DataSource = TableFoodVitamin();
            gcFoods.ReadOnly = true;
            gcFoods.AllowUserToAddRows = false;
        }

        private void InitializeComboBox()
        {
            List<Food> foods = foodController.GetAllFoods();
            foreach (Food f in foods)
            {
                cbFood.Items.Add(String.Format("{0} - {1}", f.FoodID, f.Name));
            }

            cbWeightFood.Items.Add(Weigth.WEIGHT_G);
        }

        private DataTable TableFoodVitamin()
        {
            DataTable table = foodController.TableFood();
            table.Columns.AddRange(new DataColumn[2]{
                    new DataColumn(COLUMN_FOOD_AMOUNT),
                    new DataColumn(COLUMN_FOOD_WEIGHT)
            });

            return table;
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateFood())
                {
                    throw new Exception(Resources.ErrorNecessaryToSelectAFood);
                }
                else
                {
                    AddFoodMeal();
                }
            }
            catch (Exception ex)
            {
                MessageBoxErrorType(ex.Message);
            }
        }

        private void MessageBoxErrorType(String error)
        {
            MessageBox.Show(error, TitleFactory.GetTitle(this.GetType()), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddFoodMeal()
        {
            string[] food = cbFood.Text.Split('-');
            DataTable tableFood = (DataTable)gcFoods.DataSource;
            if (tableFood.Select(COLUMN_FOOD_ID + "=" + food[0].Trim()).Count() > 0)
            {
                throw new Exception(Resources.ErrorFoodAlreadyExistInMeal);
            }
            else
            {
                DataRow row = tableFood.Rows.Add();
                row[COLUMN_FOOD_ID] = food[0].Trim();
                row[COLUMN_FOOD_NAME] = food[1].Trim();
                row[COLUMN_FOOD_AMOUNT] = txtAmount.Text;
                row[COLUMN_FOOD_WEIGHT] = cbWeightFood.Text;
            }
        }

        private bool ValidateFood()
        {
            if (cbFood.Text.Length == 0)
            {
                throw new Exception(Resources.ErrorNecessaryToSelectAFood);
            }
            else if (txtAmount.Text.Length == 0)
            {
                throw new Exception(Resources.ErrorNecessaryToFillAmountOfFood);
            }
            else if (cbWeightFood.Text.Length == 0)
            {
                throw new Exception(Resources.ErrorNecessaryToSelectWeightOfFood);
            }
            else
            {
                return true;
            }
        }

        private void btnSaveMeal_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateController())
                {
                    Meal meal = new Meal()
                    {
                        Date = dateTimePicker1.Value,
                        Id = mealController.GetNextId(),
                        User = user
                    };
                    meal.Foods = GetAllFoods(meal.Id);
                    if (mealController.AddMeal(meal))
                    {
                        MessageBox.Show(Resources.MealAddedWithSuccess, TitleFactory.GetTitle(this.GetType()),
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBoxErrorType(ex.Message);
            }
        }

        private bool ValidateController()
        {
            if (dateTimePicker1.Text.Length == 0)
            {
                throw new Exception(Resources.ErrorNecessaryToPickADateForMeal);
            }
            else if (!ValidateGrid())
            {
                throw new Exception(Resources.ErrorNeedToAddFoodToMeal);
            }
            else
            {
                return true;
            }
        }

        private bool ValidateGrid()
        {
            DataTable meal = (DataTable)gcFoods.DataSource;
            return meal.Rows.Count > 0;
        }

        private List<MealFood> GetAllFoods(int mealId)
        {
            List<MealFood> mealFoods = new List<MealFood>();
            DataTable tableFoods = (DataTable)gcFoods.DataSource;
            foreach (DataRow food in tableFoods.Rows)
            {                
                mealFoods.Add(new MealFood()
                {
                    FoodId = int.Parse(food[COLUMN_FOOD_ID].ToString()),
                    Amount = double.Parse(food[COLUMN_FOOD_AMOUNT].ToString()),
                    Weigth = food[COLUMN_FOOD_WEIGHT].ToString(),                    
                });
            }

            return mealFoods;
        }

    }
}
