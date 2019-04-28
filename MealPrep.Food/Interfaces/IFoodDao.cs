using MealPrep.Food.Model;
using System.Collections.Generic;

namespace MealPrep.Food.Interfaces
{
    public interface IFoodDao
    {
        bool AddFood(FoodEntity food);
        bool AddFoodVitamin(List<FoodVitamin> foodVitamins);
        List<FoodEntity> GetAllFoods();
        int GetNextID();                
    }
}
