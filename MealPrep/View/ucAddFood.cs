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

namespace MealPrep.View
{
    public partial class ucAddFood : UserControl
    {
        private FoodController foodController;
        private VitaminController vitaminController;
        private const String ERROR_NECESSARY_FULL_FILL_CORRECTLY = "It's necessary to full fill all fields correctly.";
        private const String ERROR_NECESSARY_TO_SELECT_A_VITAMIN = "Error! It's necessary to select a vitamin.";
        private const String ERROR_VITAMIN_ALREADY_EXIST_IN_FOOD = "Error! Vitamin already exist in this food.";
        private const String MESSAGE_FODD_ADD_WITH_SUCCESS = "Food add with success";

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
            gcVitamins.DataSource = vitaminController.TableVitamin();
            gcVitamins.ReadOnly = true;
            gcVitamins.AllowUserToAddRows = false;
        }

        private void InitializeComboBox()
        {
            List<Vitamin> vitamins = vitaminController.GetAllVitamins();
            foreach(Vitamin v in vitamins)
            {
                cbVitamins.Items.Add(String.Format("{0} - {1}", v.VitaminID, v.Name));
            }            

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
            catch(Exception ex)
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
                if (foodController.AddFood(new Food()
                {
                    FoodID = foodController.GetNextId(),
                    Name = txtFoodName.Text,
                    Amount = double.Parse(txtAmount.Text),
                    Calories = double.Parse(txtCalories.Text),
                    Carbs = double.Parse(txtCarbs.Text),
                    Protein = double.Parse(txtProtein.Text),
                    Fat = double.Parse(txtFat.Text)                    
                }))
                {
                    MessageBoxInformationType(MESSAGE_FODD_ADD_WITH_SUCCESS);
                }               
            }
        }

        private void btnAddVitamin_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbVitamins.Text.Length == 0)
                {
                    throw new Exception(ERROR_NECESSARY_TO_SELECT_A_VITAMIN);
                }
                else
                {
                    string[] vitamin = cbVitamins.Text.Split('-');
                    DataTable tableVitamin = (DataTable) gcVitamins.DataSource;
                    if (tableVitamin.Select("ID=" + vitamin[0].Trim()).Count() > 0)
                    {
                        throw new Exception(ERROR_VITAMIN_ALREADY_EXIST_IN_FOOD);
                    }
                    else
                    {
                        DataRow row = tableVitamin.Rows.Add();
                        row["ID"] = vitamin[0].Trim();
                        row["NAME"] = vitamin[1].Trim();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBoxErrorType(ex.Message);
            }            
        }
    }
}
