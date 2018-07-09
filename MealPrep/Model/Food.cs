using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Model
{
    public class Food
    {
        public int FoodID { get; }
        public double Amount { get; }
        public string Name { get; }
        public double Calories { get; }
        public double Carbs { get; }
        public double Fat { get; }
        public double Protein { get; }

        public Food(double amount, string name, double calories, double carbs, double fat, double protein)
        {
            this.Amount = amount;
            this.Name = name;
            this.Calories = calories;
            this.Carbs = carbs;
            this.Fat = fat;
            this.Protein = protein;
        }
    }
}
