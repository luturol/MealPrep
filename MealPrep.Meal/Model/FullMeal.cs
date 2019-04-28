using MealPrep.Food.Model;
using System;
using System.Collections.Generic;

namespace MealPrep.Model
{
    public class FullMeal
    {
        public int MealId { get; set; }
        public double Amount { get; set; }
        public string Weigth { get; set; }
        public List<FoodEntity> Foods { get; set; }
        public double Calories { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
        public double Protein { get; set; }
        public DateTime Date { get; set; }
    }
}
