using MealPrep.Login.Model;
using MealPrep.Meal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Meal.Interfaces
{
    public interface IMealDao
    {
        List<MealEntity> GetAllMealsFromUser(User user);
        bool AddMeal(MealEntity meal, User user);        
        int GetNextId();
        bool AddMealFood(List<MealFood> mealFoods, MealEntity meal);        
        List<MealFood> GetMealFoods(MealEntity meal);
    }
}
