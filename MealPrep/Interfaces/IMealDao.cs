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
        int GetNextId();
        bool AddMealFood(List<MealFood> mealFoods, Meal meal);        
        List<MealFood> GetMealFoods(Meal meal);
    }
}
