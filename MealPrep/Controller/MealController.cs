﻿using MealPrep.Repository;
using MealPrep.Interfaces;
using MealPrep.Model;
using MealPrep.Useful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealPrep.Properties;

namespace MealPrep.Controller
{
    public class MealController : IMealController
    {
        private IMealDao mealDao;
        private IFoodDao foodDao;

        public MealController(IMealDao mealDao, IFoodDao foodDao)
        {
            this.mealDao = mealDao;
            this.foodDao = foodDao;
        }

        public bool AddMeal(Meal meal)
        {
            if (GetAllMeals(meal.User).Exists(m => m.Id == meal.Id))
            {
                throw new Exception(Resources.ErrorMealAlreadyExist);
            }
            else
            {
                return mealDao.AddMeal(meal);
            }
        }

        public bool AddMealFood(Meal meal)
        {
            return mealDao.AddMealFood(meal);
        }

        private FullMeal CreateFullMeal(Meal meal)
        {
            var amount = meal.Foods.Sum(a => a.Amount);
            List<int> foodIds = meal.Foods.Select(e => e.FoodId).ToList();
            List<Food> foods = foodDao.GetAllFoods().FindAll(food => foodIds.Contains(food.FoodID));
            double calories = 0;
            double carbs = 0;
            double protein = 0;
            double fat = 0;
            foreach (var food in foods)
            {
                var amountTotal = meal.Foods.First(f => f.FoodId == food.FoodID).Amount;
                calories += UsefulAlgorithms.By3Rule(amountTotal, food.Calories, food.Amount);
                carbs += UsefulAlgorithms.By3Rule(amountTotal, food.Carbs, food.Amount);
                protein += UsefulAlgorithms.By3Rule(amountTotal, food.Protein, food.Amount);
                fat += UsefulAlgorithms.By3Rule(amountTotal, food.Fat, food.Amount);
            }

            return new FullMeal()
            {
                Amount = amount,
                MealId = meal.Id,
                Calories = calories,
                Carbs = carbs,
                Fat = fat,
                Protein = protein,
                Weigth = "g",
                Date = meal.Date
            };
        }

        public List<Meal> GetAllMeals(User user)
        {
            return mealDao.GetAllMealsFromUser(user);
        }

        public List<FullMeal> GetMealWithFoods(User user)
        {
            List<FullMeal> fullMeals = new List<FullMeal>();
            List<Meal> meals = GetAllMeals(user);

            foreach (Meal m in meals)
            {               
                fullMeals.Add(CreateFullMeal(m));
            }
            return fullMeals;
        }

        public int GetNextId()
        {
            return mealDao.GetNextId();
        }
    }
}
