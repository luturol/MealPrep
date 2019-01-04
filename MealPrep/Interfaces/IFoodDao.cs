using MealPrep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Interfaces
{
    public interface IFoodDao
    {
        bool AddFood(Food food);
        bool AddFoodVitamin(List<FoodVitamin> foodVitamins);
        List<Food> GetAllFoods();
        int GetNextID();                
    }
}
