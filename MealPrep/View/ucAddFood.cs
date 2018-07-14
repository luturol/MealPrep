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
using MealPrep.Utiles;

namespace MealPrep.View
{
    public partial class ucAddFood : UserControl
    {
        private FoodController foodController;
        private const string ERROR_NECESSARY_FULL_FILL_CORRECTLY = "It's necessary to full fill all fields correctly.";

        public ucAddFood(FoodController foodController)
        {
            this.foodController = foodController;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFood();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "New Food", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Food add with success", "New Food", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }               
            }
        }
    }
}
