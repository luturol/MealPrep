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

        public MealController(MealDao mealDao)
        {
            this.mealDao = mealDao;
        }

        public List<Meal> GetAllMeals(User user)
        {
            return mealDao.GetAllMealsFromUser(user);
        }
    }
}
