﻿using MealPrep.Interfaces;
using MealPrep.Model;
using MealPrep.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealPrep.Meal.Model;
using MealPrep.Login.Model;
using MealPrep.Food.Controller;
using MealPrep.Meal.Interfaces;

namespace MealPrep.Meal.Controller
{
    public class MealController : IMealController
    {
        private IMealDao mealDao;
        private FoodController foodController;
        private const String ERROR_MEAL_ALREADY_EXIST = "Error! Meal already exist.";

        public MealController(IMealDao mealDao, FoodController foodController)
        {
            this.mealDao = mealDao;
            this.foodController = foodController;
        }

        public bool AddMeal(MealEntity meal, User user)
        {
            if (GetAllMeals(user).Exists(m => m.MealID == meal.MealID))
            {
                throw new Exception(ERROR_MEAL_ALREADY_EXIST);
            }
            else
            {
                return mealDao.AddMeal(meal, user);
            }
        }

        public bool AddMealFood(List<MealFood> mealFoods, MealEntity meal)
        {
            return mealDao.AddMealFood(mealFoods, meal);
        }

        private FullMeal CreateFullMeal(MealEntity meal)
        {
            var amount = meal.MealFoods.Sum(a => a.Amount);
            double calories = 0;
            double carbs = 0;
            double protein = 0;
            double fat = 0;
            foreach (var f in meal.MealFoods)
            {
                calories += UsefulAlgorithms.By3Rule(f.Amount, f.Food.Calories, f.Food.Amount);
                carbs += UsefulAlgorithms.By3Rule(f.Amount, f.Food.Carbs, f.Food.Amount);
                protein += UsefulAlgorithms.By3Rule(f.Amount, f.Food.Protein, f.Food.Amount);
                fat += UsefulAlgorithms.By3Rule(f.Amount, f.Food.Fat, f.Food.Amount);
            }

            return new FullMeal()
            {
                Amount = amount,
                Foods = meal.MealFoods.Select(f => f.Food).ToList(),
                MealId = meal.MealID,
                Calories = calories,
                Carbs = carbs,
                Fat = fat,
                Protein = protein,
                Weigth = "g",
                Date = meal.MealDate
            };
        }

        public List<MealEntity> GetAllMeals(User user)
        {
            return mealDao.GetAllMealsFromUser(user);
        }

        public List<FullMeal> GetMealWithFoods(User user)
        {
            List<FullMeal> fullMeals = new List<FullMeal>();
            List<MealEntity> meals = GetAllMeals(user);

            foreach (MealEntity m in meals)
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