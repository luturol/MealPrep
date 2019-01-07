using MealPrep.Dao;
using MealPrep.Interfaces;
using MealPrep.Model;
using MealPrep.Useful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Controller
{
    public class MealController : IMealController
    {
        private IMealDao mealDao;
        private FoodController foodController;
        private const String ERROR_MEAL_ALREADY_EXIST = "Error! Meal already exist.";

        public MealController(IMealDao mealDao, FoodController foodController)
        {
            this.mealDao = mealDao;
            this.foodController = foodController;
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

        public bool AddMealFood(List<MealFood> mealFoods, Meal meal)
        {
            return mealDao.AddMealFood(mealFoods, meal);
        }

        private FullMeal CreateFullMeal(Meal meal)
        {
            var amount = meal.MealFoods.Sum(a => a.Amount);
            double calories = 0;
            double carbs = 0;
            double protein = 0;
            double fat = 0;
            foreach (var f in meal.MealFoods)
            {
                calories += UsefulAlgorithms.By3Rule(f.Amount, f.Food.Calories, f.Food.Amount);
                carbs += UsefulAlgorithms.By3Rule(f.Amount, f.Food.Carbs, f.Food.Amount);
                protein += UsefulAlgorithms.By3Rule(f.Amount, f.Food.Protein, f.Food.Amount);
                fat += UsefulAlgorithms.By3Rule(f.Amount, f.Food.Fat, f.Food.Amount);
            }

            return new FullMeal()
            {
                Amount = amount,
                Foods = meal.MealFoods.Select(f => f.Food).ToList(),
                Meal = meal,
                Calories = calories,
                Carbs = carbs,
                Fat = fat,
                Protein = protein,
                Weigth = "g",
                Date = meal.MealDate
            };
        }

        public List<Meal> GetAllMeals(User user)
        {
            return mealDao.GetAllMealsFromUser(user);
        }

        public List<FullMeal> GetMealWithFoods(User user)
        {
            List<FullMeal> fullMeals = new List<FullMeal>();
            List<Meal> meals = GetAllMeals(user);

            foreach (Meal m in meals)
            {               
                fullMeals.Add(CreateFullMeal(m));
            }
            return fullMeals;
        }

        public FullMeal GetFullMealByMealID(int mealID)
        {
            return CreateFullMeal(mealDao.GetMealByID(mealID));
        }

        public int GetNextId()
        {
            return mealDao.GetNextId();
        }
    }
}
