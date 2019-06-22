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
using System.Text.RegularExpressions;
using MealPrep.Model;
using MealPrep.Useful;
using MealPrep.Interfaces;
using MealPrep.Properties;

namespace MealPrep.View
{
    public partial class ucAddFood : UserControl, IView
    {
        private FoodController foodController;
        private VitaminController vitaminController;                                       
        private const string COLUMN_FOODVITAMIN_ID = "ID";
        private const string COLUMN_FOOD_VITAMIN_NAME = "NAME";
        private const string COLUMN_FOODVITAMIN_AMOUNT = "AMOUNT";
        private const string COLUMN_FOODVITAMIN_WEIGHT = "WEIGHT";

        public ucAddFood(FoodController foodController, VitaminController vitaminController)
        {
            this.foodController = foodController;
            this.vitaminController = vitaminController;
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
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
                throw new Exception(Resources.ErrorNecessaryToFillAllFieldsCorrectly);
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
                Food f = new Food()
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
                    MessageBoxInformationType(Resources.FoodAddedWithSuccess);
                }
            }
        }

        private List<FoodVitamin> GetAllVitamins(Food food)
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
                    throw new Exception(Resources.ErrorItsNecessaryToSelectAVitamin);
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
                throw new Exception(Resources.ErrorVitaminAleradyExisInThisFood);
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
                throw new Exception(Resources.ErrorItsNecessaryToSelectAVitamin);
            }
            else if (txtAmountVitamin.Text.Length == 0)
            {
                throw new Exception(Resources.ErrorItsNecessaryToFillAmountOfVitamin);
            }
            else if (cbWeightVitamin.Text.Length == 0)
            {
                throw new Exception(Resources.ErrorItsNecessaryToFillWeightOfVitamin);
            }
            else
            {
                return true;
            }
        }
    }
}
