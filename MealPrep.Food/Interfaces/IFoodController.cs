using MealPrep.Food.Model;
using System.Collections.Generic;
namespace MealPrep.Food.Interfaces
{
    public interface IFoodController
    {
        bool AddFood(FoodEntity food);
        List<FoodEntity> GetAllFoods();
        int GetNextId();
    }
}
