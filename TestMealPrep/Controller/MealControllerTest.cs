using System;
using System.Collections.Generic;
using MealPrep.Controller;
using MealPrep.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestMealPrep.Dao;

namespace TestMealPrep.Controller
{
    [TestClass]
    public class MealControllerTest
    {
        private static readonly User USER = new User("rafael", "rafael");

        [TestMethod]
        public void ShouldBeAbleToAddNewMeal()
        {
            FakeFoodDao foodDao = new FakeFoodDao();
            FakeMealDao mealDao = new FakeMealDao();
            FoodController foodController = new FoodController(foodDao);

            Food food = new Food()
            {
                FoodID = 1,
                Name = "Chicken",
                Amount = 100,
                Calories = 100,
                Carbs = 100,
                Fat = 100,
                Protein = 100,
                FoodVitamins = new List<FoodVitamin>()
            };

            foodController.AddFood(food);

            MealController mealController = new MealController(mealDao, foodController);

            Meal meal = new Meal()
            {
                MealDate = DateTime.Today,
                MealID = 0,
                User = USER
            };
           
            List<MealFood> mealFoods = new List<MealFood>();
            mealFoods.Add(new MealFood()
            {
                Amount = 100,
                Food = food,
                Meal = meal,
                Weigth = "g"
            });

            meal.MealFoods = mealFoods;

            Assert.IsTrue(mealController.AddMeal(meal, USER));
        }
    }
}
