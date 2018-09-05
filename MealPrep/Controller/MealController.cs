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
        private const String ERROR_MEAL_ALREADY_EXIST = "Error! Meal already exist.";

        public MealController(MealDao mealDao)
        {
            this.mealDao = mealDao;
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
    }
}
