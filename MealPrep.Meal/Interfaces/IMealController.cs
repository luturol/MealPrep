using MealPrep.Login.Model;
using MealPrep.Meal.Model;
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
        bool AddMeal(MealEntity meal, User user);
        bool AddMealFood(List<MealFood> mealFoods, MealEntity meal);
        List<MealEntity> GetAllMeals(User user);
        List<FullMeal> GetMealWithFoods(User user);
        int GetNextId();                    
    }
}
