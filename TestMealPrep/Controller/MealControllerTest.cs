using System;
using System.Collections.Generic;
using MealPrep.Controller;
using MealPrep.Interfaces;
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

        private Meal CreateMeal(int id, User user, DateTime mealDate)
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

            var meal = new Meal()
            {

                Date = mealDate,
                Id = id,
                User = user,
                Foods = new List<Food>() { food }
            };

            return meal;
        }

        [TestInitialize]
        public void Initialize()
        {
            var controller = MockRepository.GenerateStub<IMealController>();
        }

        [TestMethod]
        public void ShouldBeAbleToAddNewMeal()
        {
            //Arrange            
            var mealController = MockRepository.GenerateMock<MealController>(new FakeMealDao(), new FoodController(new FakeFoodDao()));
            var meal = CreateMeal(0, USER, DateTime.Today);
            mealController.Stub(x => x.GetAllMeals(Arg<User>.Is.Anything)).Return(new List<Meal>());

            //Act
            bool actual = mealController.AddMeal(meal);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeAbleToCalculateMacrosFromMeals()
        {
            //Arrange
            var mealController = MockRepository.GenerateMock<MealController>(new FakeMealDao(), new FoodController(new FakeFoodDao()));
            var meal = CreateMeal(0, USER, DateTime.Today);
            mealController.Stub(x => x.GetAllMeals(Arg<User>.Is.Anything)).Return(new List<Meal>() { meal });

            //Act
            FullMeal fullMeal = mealController.GetMealWithFoods(USER).Find(e => e.MealId == 0);

            //Assert
            Assert.AreEqual(fullMeal.Calories, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Error! Meal already exist.")]
        public void ShouldBeAbleToUpdateMealGivingMealWithExistingID()
        {
            //Arrange
            var mealController = MockRepository.GenerateMock<MealController>(new FakeMealDao(), new FoodController(new FakeFoodDao()));
            var meal = CreateMeal(0, USER, DateTime.Today);
            mealController.Stub(x => x.GetAllMeals(Arg<User>.Is.Anything)).Return(new List<Meal>() { meal });
            var newMeal = CreateMeal(0, USER, DateTime.Today.AddDays(1));

            //Act
            bool expected = mealController.AddMeal(meal);
        }
    }
}
