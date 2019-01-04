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

        public bool AddMeal(Meal meal, User user)
        {
            if(!GetAllMealsFromUser(user).Exists(m => m.MealID == meal.MealID))
            {
                fakeDB.Add(meal.MealID, meal);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddMealFood(List<MealFood> mealFoods, Meal meal)
        {
            foreach(MealFood mealFood in mealFoods)
            {
                meal.MealFoods.Add(mealFood);
            }

            return true;
        }   
        
        public List<Meal> GetAllMealsFromUser(User user)
        {
            return fakeDB.Values.ToList();
        }

        public List<MealFood> GetMealFoods(Meal meal)
        {
            return fakeDB.Values.SingleOrDefault(m => m.MealID == meal.MealID).MealFoods;
        }

        public int GetNextId()
        {
            return 0;
        }
    }
}
