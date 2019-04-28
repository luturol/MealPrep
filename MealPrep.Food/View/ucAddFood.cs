using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using MealPrep.Utils;
using MealPrep.Food.Controller;
using MealPrep.Food.Model;

namespace MealPrep.Food.View
{
    public partial class ucAddFood : UserControl
    {
        private FoodController foodController;
        private VitaminController vitaminController;
        private const String ERROR_NECESSARY_FULL_FILL_CORRECTLY = "It's necessary to full fill all fields correctly.";
        private const String ERROR_NECESSARY_TO_SELECT_A_VITAMIN = "Error! It's necessary to select a vitamin.";
        private const String ERROR_VITAMIN_ALREADY_EXIST_IN_FOOD = "Error! Vitamin already exist in this food.";
        private const String ERRO_NECESSARY_TO_FILL_AMOUNT_OF_VITAMIN = "Error! It's necessary to fill amount of vitamin";
        private const String ERRO_NECESSARY_SELECT_WEIGHT_OF_VITAMIN = "Erro! It's necessary to select a weight of the vitamin";
        private const String MESSAGE_FODD_ADD_WITH_SUCCESS = "Food add with success";
        private const String COLUMN_FOODVITAMIN_ID = "ID";
        private const String COLUMN_FOOD_VITAMIN_NAME = "NAME";
        private const String COLUMN_FOODVITAMIN_AMOUNT = "AMOUNT";
        private const String COLUMN_FOODVITAMIN_WEIGHT = "WEIGHT";

        public ucAddFood(FoodController foodController, VitaminController vitaminController)
        {
            this.foodController = foodController;
            this.vitaminController = vitaminController;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            InitializeComboBox();
            gcVitamins.DataSource = TableFoodVitamin();
            gcVitamins.ReadOnly = true;
            gcVitamins.AllowUserToAddRows = false;
        }

        private DataTable TableFoodVitamin()
        {
            DataTable table = vitaminController.TableVitamin();
            table.Columns.AddRange(new DataColumn[2]{
                    new DataColumn(COLUMN_FOODVITAMIN_AMOUNT),
                    new DataColumn(COLUMN_FOODVITAMIN_WEIGHT)
            });

            return table;
        }

        private void InitializeComboBox()
        {
            List<Vitamin> vitamins = vitaminController.GetAllVitamins();
            foreach (Vitamin v in vitamins)
            {
                cbVitamins.Items.Add(String.Format("{0} - {1}", v.VitaminID, v.Name));
            }

            cbWeightVitamin.Items.Add(Weigth.WEIGTH_MG);
            cbWeightVitamin.Items.Add(Weigth.WEIGHT_G);
            cbWeightVitamin.Items.Add(Weigth.WEIGHT_KG);
        }

        private void MessageBoxErrorType(String error)
        {
            MessageBox.Show(error, TitleFactory.GetTitle(this.GetType()), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MessageBoxInformationType(String information)
        {
            MessageBox.Show(information, TitleFactory.GetTitle(this.GetType()), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFood();
            }
            catch (Exception ex)
            {
                MessageBoxErrorType(ex.Message);
            }
        }

        private bool ValidateControl()
        {
            if (UsefulAlgorithms.ValidateEmptyString(txtFoodName.Text) &&
                ValidateNumbersAndEmptyString(txtAmount.Text) &&
                ValidateNumbersAndEmptyString(txtCalories.Text) &&
                ValidateNumbersAndEmptyString(txtCarbs.Text) &&
                ValidateNumbersAndEmptyString(txtFat.Text) &&
                ValidateNumbersAndEmptyString(txtProtein.Text))
            {
                return true;
            }
            else
            {
                throw new Exception(ERROR_NECESSARY_FULL_FILL_CORRECTLY);
            }
        }

        private bool ValidateNumbersAndEmptyString(string value)
        {
            return UsefulAlgorithms.ValidateEmptyString(value) && UsefulAlgorithms.ValidateNumber(value);
        }

        private void SaveFood()
        {            
            if (ValidateControl())
            {
                FoodEntity f = new FoodEntity()
                {
                    FoodID = foodController.GetNextId(),
                    Name = txtFoodName.Text,
                    Amount = double.Parse(txtAmount.Text),
                    Calories = double.Parse(txtCalories.Text),
                    Carbs = double.Parse(txtCarbs.Text),
                    Protein = double.Parse(txtProtein.Text),
                    Fat = double.Parse(txtFat.Text)                    
                };
                f.FoodVitamins = GetAllVitamins(f);
                if (foodController.AddFood(f) && foodController.AddFoodVitamin(f.FoodVitamins))
                {
                    MessageBoxInformationType(MESSAGE_FODD_ADD_WITH_SUCCESS);
                }
            }
        }

        private List<FoodVitamin> GetAllVitamins(FoodEntity food)
        {
            List<FoodVitamin> foodVitamins = new List<FoodVitamin>();
            DataTable tableVitamins = (DataTable) gcVitamins.DataSource;
            foreach (DataRow vitamin in tableVitamins.Rows)
            {
                foodVitamins.Add(new FoodVitamin
                {
                    Vitamin = new Vitamin()
                    {
                        VitaminID = int.Parse(vitamin[COLUMN_FOODVITAMIN_ID].ToString()),
                        Name = vitamin[COLUMN_FOOD_VITAMIN_NAME].ToString(),
                    },
                    Amount = double.Parse(vitamin[COLUMN_FOODVITAMIN_AMOUNT].ToString()),
                    Weigth = vitamin[COLUMN_FOODVITAMIN_WEIGHT].ToString(),
                    Food = food
                });
            }
            return foodVitamins;
        }

        private void btnAddVitamin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateFoodVitamin())
                {
                    throw new Exception(ERROR_NECESSARY_TO_SELECT_A_VITAMIN);
                }
                else
                {
                    AddFoodVitamin();
                }
            }
            catch (Exception ex)
            {
                MessageBoxErrorType(ex.Message);
            }
        }

        private void AddFoodVitamin()
        {
            string[] vitamin = cbVitamins.Text.Split('-');
            DataTable tableVitamin = (DataTable)gcVitamins.DataSource;
            if (tableVitamin.Select(COLUMN_FOODVITAMIN_ID + "=" + vitamin[0].Trim()).Count() > 0)
            {
                throw new Exception(ERROR_VITAMIN_ALREADY_EXIST_IN_FOOD);
            }
            else
            {
                DataRow row = tableVitamin.Rows.Add();
                row[COLUMN_FOODVITAMIN_ID] = vitamin[0].Trim();
                row[COLUMN_FOOD_VITAMIN_NAME] = vitamin[1].Trim();
                row[COLUMN_FOODVITAMIN_AMOUNT] = txtAmountVitamin.Text;
                row[COLUMN_FOODVITAMIN_WEIGHT] = cbWeightVitamin.Text;
            }
        }

        private bool ValidateFoodVitamin()
        {
            if (cbVitamins.Text.Length == 0)
            {
                throw new Exception(ERROR_NECESSARY_TO_SELECT_A_VITAMIN);
            }
            else if (txtAmountVitamin.Text.Length == 0)
            {
                throw new Exception(ERRO_NECESSARY_TO_FILL_AMOUNT_OF_VITAMIN);
            }
            else if (cbWeightVitamin.Text.Length == 0)
            {
                throw new Exception(ERRO_NECESSARY_SELECT_WEIGHT_OF_VITAMIN);
            }
            else
            {
                return true;
            }
        }
    }
}
