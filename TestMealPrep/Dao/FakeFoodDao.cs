using MealPrep.Food.Interfaces;
using MealPrep.Food.Model;
using MealPrep.Interfaces;
using MealPrep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMealPrep.Dao
{
    public class FakeFoodDao : IFoodDao
    {
        private Dictionary<int, FoodEntity> fakeDB;

        public FakeFoodDao()
        {
            fakeDB = new Dictionary<int, FoodEntity>();
        }

        public bool AddFood(FoodEntity food)
        {
            if(!GetAllFoods().Exists(f => f.FoodID == food.FoodID))
            {
                fakeDB.Add(food.FoodID, food);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddFoodVitamin(List<FoodVitamin> foodVitamins)
        {
            throw new NotImplementedException();
        }

        public List<FoodEntity> GetAllFoods()
        {
            return fakeDB.Values.ToList();
        }

        public int GetNextID()
        {
            return 0;
        }
    }
}
