using MealPrep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Interfaces
{
    public interface IMealController
    {
        bool AddMeal(Meal meal, User user);
        bool AddMealFood(List<MealFood> mealFoods, Meal meal);
        List<Meal> GetAllMeals(User user);
        List<FullMeal> GetMealWithFoods(User user);
        int GetNextId();                    
    }
}
