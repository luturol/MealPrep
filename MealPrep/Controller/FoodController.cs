using MealPrep.Repository;
using MealPrep.Interfaces;
using MealPrep.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealPrep.Properties;

namespace MealPrep.Controller
{
    public class FoodController : IFoodController
    {
        private IFoodDao foodDao;   

        public FoodController(IFoodDao foodDao)
        {
            this.foodDao = foodDao;
        }        

        public bool AddFood(Food food)
        {
            if(GetAllFoods().Exists(p => p.FoodID == food.FoodID))
            {
                throw new Exception(Resources.ErrorFoodAlreadyExist);
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

        public bool AddFoodVitamin(List<FoodVitamin> foodVitamins)
        {
            return foodDao.AddFoodVitamin(foodVitamins);
        }

        public DataTable TableFood()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Name");

            return table;
        }
    }
}
