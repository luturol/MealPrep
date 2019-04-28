using MealPrep.Login.Model;
using System;
using System.Collections.Generic;

namespace MealPrep.Meal.Model
{
    public class MealEntity
    {
        public int MealID { get; set; }
        public DateTime MealDate { get; set; }
        public User User { get; set; }        
        public List<MealFood> MealFoods { get; set; }
    }
}
