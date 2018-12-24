﻿using MealPrep.Dao;
using MealPrep.Model;
using MealPrep.Useful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Controller
{
    public class MealController
    {
        private MealDao mealDao;
        private FoodController foodController;
        private const String ERROR_MEAL_ALREADY_EXIST = "Error! Meal already exist.";

        public MealController(MealDao mealDao, FoodController foodController)
        {
            this.mealDao = mealDao;
            this.foodController = foodController;
        }

        public List<Meal> GetAllMeals(User user)
        {
            return mealDao.GetAllMealsFromUser(user);
        }

        public bool AddMeal(Meal meal, User user)
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

        public int GetNextId()
        {
            return mealDao.GetNextId();
        }

        public bool AddMealFood(List<MealFood> mealFoods)
        {
            return mealDao.AddMealFood(mealFoods);
        }

        public List<FullMeal> GetMealWithFoods(User user)
        {
            List<FullMeal> fullMeals = new List<FullMeal>();
            List<Meal> meals = GetAllMeals(user);
            
            foreach (Meal m in meals)
            {                 
                var amount = m.MealFoods.Sum(a => a.Amount);
                double calories = 0;
                double carbs = 0;
                double protein = 0;
                double fat = 0;
                foreach (var f in m.MealFoods)
                {
                    calories += UsefulAlgorithms.By3Rule(amount, f.Food.Calories, f.Amount);
                    carbs += UsefulAlgorithms.By3Rule(amount, f.Food.Carbs, f.Amount);
                    protein += UsefulAlgorithms.By3Rule(amount, f.Food.Protein, f.Amount);
                    fat += UsefulAlgorithms.By3Rule(amount, f.Food.Fat, f.Amount);
                }
                fullMeals.Add(new FullMeal()
                {
                    Amount = amount,
                    Foods = m.MealFoods.Select(f => f.Food).ToList(),
                    MealId = m.MealID,
                    Calories = calories,
                    Carbs = carbs,
                    Fat = fat,
                    Protein = protein,
                    Weigth = "g",
                    Date = m.MealDate
                });
            }
            return fullMeals;
        }

    }
}
