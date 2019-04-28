using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MealPrep.Meal.Controller;
using MealPrep.Meal.Model;
using MealPrep.Food.Controller;
using MealPrep.Login.Model;
using MealPrep.Food.Model;
using MealPrep.Utils;

namespace MealPrep.Meal.View
{
    public partial class ucAddMeal : UserControl
    {
        private FoodController foodController;
        private MealController mealController;
        private User user;
        private const String MESSAGE_MEAL_ADD_WITH_SUCCESS = "Meal add with success!";
        private const String ERROR_NECESSARY_TO_SELECT_A_FOOD = "Error! It's necessary to select a food.";
        private const String ERROR_FOOD_ALREADY_EXIST_IN_MEAL = "Error! Food already exist in this meal.";
        private const String ERRO_NECESSARY_TO_FILL_AMOUNT_OF_FOOD = "Error! It's necessary to fill amount of food";
        private const String ERRO_NECESSARY_SELECT_WEIGHT_OF_FOOD = "Erro! It's necessary to select a weight of the food";

        private const String COLUMN_FOOD_ID = "ID";
        private const String COLUMN_FOOD_NAME = "NAME";
        private const String COLUMN_FOOD_AMOUNT = "AMOUNT";
        private const String COLUMN_FOOD_WEIGHT = "WEIGHT";

        public ucAddMeal(FoodController foodController, MealController mealController, User user)
        {
            this.foodController = foodController;
            this.mealController = mealController;
            this.user = user;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            InitializeComboBox();
            gcFoods.DataSource = TableFoodVitamin();
            gcFoods.ReadOnly = true;
            gcFoods.AllowUserToAddRows = false;
        }

        private void InitializeComboBox()
        {
            List<FoodEntity> foods = foodController.GetAllFoods();
            foreach (FoodEntity f in foods)
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
                    throw new Exception(ERROR_NECESSARY_TO_SELECT_A_FOOD);
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
                throw new Exception(ERROR_FOOD_ALREADY_EXIST_IN_MEAL);
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
                throw new Exception(ERROR_NECESSARY_TO_SELECT_A_FOOD);
            }
            else if (txtAmount.Text.Length == 0)
            {
                throw new Exception(ERRO_NECESSARY_TO_FILL_AMOUNT_OF_FOOD);
            }
            else if (cbWeightFood.Text.Length == 0)
            {
                throw new Exception(ERRO_NECESSARY_SELECT_WEIGHT_OF_FOOD);
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
                    MealEntity meal = new MealEntity()
                    {
                        MealDate = dateTimePicker1.Value,
                        MealID = mealController.GetNextId(),
                        User = user
                    };
                    meal.MealFoods = GetAllFoods(meal.MealID);
                    if(mealController.AddMeal(meal, user))
                    {
                        MessageBox.Show(MESSAGE_MEAL_ADD_WITH_SUCCESS, TitleFactory.GetTitle(this.GetType()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBoxErrorType(ex.Message);
            }
        }

        private bool ValidateController()
        {
            if (dateTimePicker1.Text.Length == 0)
            {
                throw new Exception("Error! Necessary to pick a date for the meal.");
            }
            else if (!ValidateGrid())
            {
                throw new Exception("Error! Need to add a food to the meal.");
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
                mealFoods.Add(new MealFood
                {
                    Food = foodController.GetAllFoods().Single(f => f.FoodID == int.Parse(food[COLUMN_FOOD_ID].ToString())),
                    //Meal = mealController.GetAllMeals(user).Single(m => m.MealID == mealId),
                    Amount = double.Parse(food[COLUMN_FOOD_AMOUNT].ToString()),
                    Weigth = food[COLUMN_FOOD_WEIGHT].ToString(),                    
                });
            }
            return mealFoods;
        }

    }
}
