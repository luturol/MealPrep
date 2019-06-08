using System;
using System.Collections.Generic;
using MealPrep.Controller;
using MealPrep.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TestMealPrep.Dao;

namespace TestMealPrep.Controller
{
    [TestClass]
    public class MealControllerTest
    {
        private static readonly User USER = new User("rafael", "rafael");
        private static readonly Food FOOD = new Food()
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

        private MealController CreateMealController()
        {
            FakeFoodDao foodDao = new FakeFoodDao();
            FakeMealDao mealDao = new FakeMealDao();
            FoodController foodController = new FoodController(foodDao);

            foodController.AddFood(FOOD);

            MealController mealController = new MealController(mealDao, foodController);
            return mealController;
        }

        private MealController CreateMealControllerWithMeal()
        {
            MealController mealController = CreateMealController();

            Meal meal = new Meal()
            {
                MealDate = DateTime.Today,
                MealID = 0,
                User = USER
            };

            List<MealFood> mealFoods = new List<MealFood>();
            mealFoods.Add(new MealFood()
            {
                Amount = 150,
                Food = FOOD,
                Meal = meal,
                Weigth = "g"
            });

            meal.MealFoods = mealFoods;

            mealController.AddMeal(meal, USER);

            return mealController;
        }

        [TestInitialize]
        public void Initialize()
        {
            var controller = MockRepository.GenerateStub<MealController>();
        }

        [TestMethod]
        public void ShouldBeAbleToAddNewMeal()
        {
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
            MealController mealController = CreateMealController();
            Meal meal = new Meal()
            {
                MealDate = DateTime.Today,
                MealID = 0,
                User = USER
            };
           
            List<MealFood> mealFoods = new List<MealFood>();
            mealFoods.Add(new MealFood()
            {
                Amount = 150,
                Food = food,
                Meal = meal,
                Weigth = "g"
            });

            meal.MealFoods = mealFoods;

            Assert.IsTrue(mealController.AddMeal(meal, USER));
        }
       
        [TestMethod]
        public void ShouldBeAbleToCalculateMacrosFromMeals()
        {
            MealController mealController = CreateMealControllerWithMeal();
           
            FullMeal fullMeal = mealController.GetMealWithFoods(USER).Find(e => e.MealId == 0);
            Assert.AreEqual(fullMeal.Calories, 150);
        }
    }
}
