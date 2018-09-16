using MealPrep.Dao;
using MealPrep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Controller
{
    public class MealController
    {
        private MealDao mealDao;
        private FoodController foodController;
        private const String ERROR_MEAL_ALREADY_EXIST = "Error! Meal already exist.";

        public MealController(MealDao mealDao, FoodController foodController)
        {
            this.mealDao = mealDao;
            this.foodController = foodController;
        }

        public List<Meal> GetAllMeals(User user)
        {
            return mealDao.GetAllMealsFromUser(user);
        }

        public bool AddMeal(Meal meal, User user)
        {
            if (GetAllMeals(user).Exists(m => m.MealID == meal.MealID))
            {
                throw new Exception(ERROR_MEAL_ALREADY_EXIST);
            }
            else
            {
                return mealDao.AddMeal(meal, user);
            }
        }

        public int GetNextId()
        {
            return mealDao.GetNextId();
        }

        public bool AddMealFood(List<MealFood> mealFoods)
        {
            return mealDao.AddMealFood(mealFoods);
        }

        public List<FullMeal> GetMealWithFoods(User user)
        {
            List<FullMeal> fullMeals = new List<FullMeal>();
            List<Meal> meals = GetAllMeals(user);
            List<MealFood> mealFoods = mealDao.GetMealFoods();
            var mealFoodFromUser = mealFoods.Join(meals, mealFood => mealFood.MealID, meal => meal.MealID, (mealFood, meal) => new { mealFood, meal }).ToList();
            var foods = foodController.GetAllFoods().Join(mealFoodFromUser, food => food.FoodID, meal => meal.mealFood.FoodID, (food, meal) => new { Meal = meal, Food = food });
            foreach (Meal m in meals)
            {
                var food = foods.Where(f => f.Meal.meal.MealID == m.MealID).ToList();                
                var amount = food.Sum(a => a.Meal.mealFood.Amount);
                double calories = 0;
                double carbs = 0;
                double protein = 0;
                double fat = 0;
                foreach (var f in food)
                {
                    calories += By3Rule(amount, f.Food.Calories, f.Meal.mealFood.Amount);
                    carbs += By3Rule(amount, f.Food.Carbs, f.Meal.mealFood.Amount);
                    protein += By3Rule(amount, f.Food.Protein, f.Meal.mealFood.Amount);
                    fat += By3Rule(amount, f.Food.Fat, f.Meal.mealFood.Amount);
                }
                fullMeals.Add(new FullMeal()
                {
                    Amount = amount,
                    Foods = food.Select(f => f.Food).ToList(),
                    MealId = m.MealID,
                    Calories = calories,
                    Carbs = carbs,
                    Fat = fat,
                    Protein = protein,
                    Weigth = "g"
                });
            }
            return fullMeals;
        }

        private double By3Rule(double value1, double value2, double value3)
        {
            // x - value1
            // value2 = value3
            return (value1 * value2) / value3;
        }
    }
}
