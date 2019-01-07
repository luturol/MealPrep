using MealPrep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Interfaces
{
    public interface IMealDao
    {
        List<Meal> GetAllMealsFromUser(User user);
        bool AddMeal(Meal meal, User user);                
        bool AddMealFood(List<MealFood> mealFoods, Meal meal);        
        Meal GetMealByID(int mealID);
        List<MealFood> GetMealFoods(Meal meal);
        int GetNextId();
    }
}
