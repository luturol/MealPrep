using MealPrep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Interfaces
{
    interface IFoodController
    {
        bool AddFood(Food food);
        List<Food> GetAllFoods();
        int GetNextId();
    }
}
