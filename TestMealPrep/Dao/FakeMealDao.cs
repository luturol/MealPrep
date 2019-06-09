using MealPrep.Interfaces;
using MealPrep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMealPrep.Dao
{
    public class FakeMealDao : IMealDao
    {
        private Dictionary<int, Meal> fakeDB;

        public FakeMealDao()
        {
            fakeDB = new Dictionary<int, Meal>();
        }

        public bool AddMeal(Meal meal)
        {
            if(!GetAllMealsFromUser(meal.User).Exists(m => m.Id == meal.Id))
            {
                fakeDB.Add(meal.Id, meal);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// There is no need for this implementation for the FakeMealDao
        /// </summary>
        /// <param name="meal"></param>
        /// <returns></returns>
        public bool AddMealFood(Meal meal)
        {
            return true;
        }

        public List<Meal> GetAllMealsFromUser(User user)
        {
            return fakeDB.Values.ToList();
        }

        public List<Food> GetMealFoods(Meal meal)
        {
            return fakeDB.Values.SingleOrDefault(m => m.Id == meal.Id).Foods;
        }

        public int GetNextId()
        {
            return 0;
        }
    }
}
