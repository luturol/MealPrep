using MealPrep.Dao;
using MealPrep.Interfaces;
using MealPrep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Controller
{
    public class FoodController : IFoodController
    {
        private FoodDao foodDao;
        private const string FOOD_ALREADY_EXIST = "Food already exist";        

        public FoodController(FoodDao foodDao)
        {
            this.foodDao = foodDao;
        }        

        public bool AddFood(Food food)
        {
            if(GetAllFoods().Exists(p => p.FoodID == food.FoodID))
            {
                throw new Exception("Food already exist");
            }
            else
            {
                return foodDao.AddFood(food);
            }            
        }

        public List<Food> GetAllFoods()
        {
            return foodDao.GetAllFoods();
        }

        public int GetNextId()
        {
            return foodDao.GetNextID();
        }
                        
    }
}
