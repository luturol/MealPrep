using MealPrep.Repository;
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
        private const string ERROR_MEAL_ALREADY_EXIST = "Error! Meal already exist.";

        public MealController(IMealDao mealDao, FoodController foodController)
        {
            this.mealDao = mealDao;
            this.foodController = foodController;
        }

        public bool AddMeal(Meal meal)
        {
            if (GetAllMeals(meal.User).Exists(m => m.Id == meal.Id))
            {
                throw new Exception(ERROR_MEAL_ALREADY_EXIST);
            }
            else
            {
                return mealDao.AddMeal(meal);
            }
        }

        public bool AddMealFood(Meal meal)
        {
            return mealDao.AddMealFood(meal);
        }

        private FullMeal CreateFullMeal(Meal meal)
        {
            var amount = meal.Foods.Sum(a => a.Amount);
            List<int> foodIds = meal.Foods.Select(e => e.FoodId).ToList();
            List<Food> foods = foodController.GetAllFoods().FindAll(food => foodIds.Contains(food.FoodID));
            double calories = 0;
            double carbs = 0;
            double protein = 0;
            double fat = 0;
            foreach (var food in foods)
            {
                calories += UsefulAlgorithms.By3Rule(food.Amount, food.Calories, food.Amount);
                carbs += UsefulAlgorithms.By3Rule(food.Amount, food.Carbs, food.Amount);
                protein += UsefulAlgorithms.By3Rule(food.Amount, food.Protein, food.Amount);
                fat += UsefulAlgorithms.By3Rule(food.Amount, food.Fat, food.Amount);
            }

            return new FullMeal()
            {
                Amount = amount,
                MealId = meal.Id,
                Calories = calories,
                Carbs = carbs,
                Fat = fat,
                Protein = protein,
                Weigth = "g",
                Date = meal.Date
            };
        }

        public virtual List<Meal> GetAllMeals(User user)
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

        public int GetNextId()
        {
            return mealDao.GetNextId();
        }
    }
}
