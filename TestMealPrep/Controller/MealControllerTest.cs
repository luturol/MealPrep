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
        private MealController mealController;
        private IFoodDao foodDao;
        private IMealDao mealDao;

        private MealController CreateMealController()
        {
            FakeFoodDao foodDao = new FakeFoodDao();
            FakeMealDao mealDao = new FakeMealDao();
            FoodController foodController = new FoodController(foodDao);

            foodController.AddFood(FOOD);

            MealController mealController = new MealController(mealDao, foodDao);
            return mealController;
        }

        private Meal CreateMeal(int id, User user, DateTime mealDate)
        {
            MealFood mealFood = new MealFood()
            {
                FoodId = 1,
                Amount = 150,
                Weigth = "g"
            };

            var meal = new Meal()
            {

                Date = mealDate,
                Id = id,
                User = user,
                Foods = new List<MealFood>() { mealFood }
            };

            return meal;
        }

        [TestInitialize]
        public void Initialize()
        {
            foodDao = MockRepository.GenerateStub<IFoodDao>();
            mealDao = MockRepository.GenerateStub<IMealDao>();
            mealController = MockRepository.GenerateMock<MealController>(mealDao, foodDao);
        }

        [TestMethod]
        public void ShouldBeAbleToAddNewMeal()
        {
            //Arrange                        
            var meal = CreateMeal(0, USER, DateTime.Today);
            mealController.Stub(x => x.GetAllMeals(Arg<User>.Is.Anything)).Return(new List<Meal>());
            mealDao.Stub(x => x.AddMeal(Arg<Meal>.Is.Anything)).Return(true);

            //Act
            bool actual = mealController.AddMeal(meal);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldBeAbleToCalculateMacrosFromMeals()
        {
            //Arrange
            var food = new Food()
            {
                FoodID = 1,
                Amount = 100,
                Calories = 100,
                Carbs = 14,
                Fat = 9,
                FoodVitamins = new List<FoodVitamin>(),
                Name = "Chicken",
                Protein = 13
            };        

            var meal = CreateMeal(0, USER, DateTime.Today);
            mealDao.Stub(x => x.GetAllMealsFromUser(Arg<User>.Is.Anything)).Return(new List<Meal>() { meal });
            foodDao.Stub(x => x.GetAllFoods()).Return(new List<Food>() { food });
            //Act
            FullMeal fullMeal = mealController.GetMealWithFoods(USER).Find(e => e.MealId == 0);

            //Assert
            Assert.AreEqual(fullMeal.Calories, 150);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Error! Meal already exist.")]
        public void ShouldBeAbleToUpdateMealGivingMealWithExistingID()
        {
            //Arrange            
            var meal = CreateMeal(0, USER, DateTime.Today);
            mealController.Stub(x => x.GetAllMeals(Arg<User>.Is.Anything)).Return(new List<Meal>() { meal });
            var newMeal = CreateMeal(0, USER, DateTime.Today.AddDays(1));

            //Act
            bool expected = mealController.AddMeal(meal);
        }
    }
}
