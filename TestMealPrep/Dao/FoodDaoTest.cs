using System;
using MealPrep.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestMealPrep.Dao;

namespace TestMealPrep
{
    [TestClass]
    public class FoodDaoTest
    {       
        [TestMethod]
        public void ShouldReturnTrueWhenAddingNewFood()
        {
            FakeFoodDao fakeDao = new FakeFoodDao();
            Food food = new Food() { FoodID = 1, Name = "Chicken Breast", Amount = 100, Calories = 165, Carbs = 0, Fat = 3.6, Protein = 31 };
            Assert.IsTrue(fakeDao.AddFood(food));
        }
    }
}
