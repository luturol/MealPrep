using MealPrep.Food.Model;

namespace MealPrep.Meal.Model
{
    public class MealFood
    {
        public FoodEntity Food { get; set; }
        public MealEntity Meal { get; set; }
        public double Amount { get; set; }
        public string Weigth { get; set; }
    }
}
