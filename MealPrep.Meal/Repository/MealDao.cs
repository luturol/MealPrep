﻿using MealPrep.Meal.Interfaces;
using MealPrep.Login.Model;
using MealPrep.Meal.Model;
using MealPrep.Food.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using MealPrep.Connection;

namespace MealPrep.Meal.Repository
{
    public class MealDao : IMealDao
    {
        private ConnectionPostgres connectionPostgres;
        private const String SELECT_ALL_MEALS_FROM_USER = "select m.id, m.username, m.date_meal from meal m where m.username = '{0}'";
        private const String SELECT_ALL_FOODS_FROM_MEAL = "select m.id, m.username, m.date_meal, f.id, f.amout, f.name, f.calories, f.carbs, f.fat, f.protein from meal m inner join meal_food mf on mf.id_meal = m.id inner join food f on f.id = mf.id_food where m.username = {0} ";
        private const String SELECT_NEXT_ID = "select max(m.id) + 1 as nextid from meal m;";
        private const String SELECT_ALL_MEAL_FOOD = "select m.id_meal, m.amount, m.weight, f.id, f.name, f.amount, f.calories, f.carbs, f.fat, f.protein from meal_food m inner join food f on m.id_food = f.id where m.id_meal = {0};";
        private const String INSERT_INTO_MEAL = "insert into meal(id, username, date_meal) values(:id, :username, to_timestamp(:date_meal, 'dd-mm-yyyy hh24:mi:ss'));";
        private const String INSERT_INTO_MEAL_FOOD = "insert into meal_food(id_meal, id_food, amount, weight) values(:id_meal, :id_food, :amount, :weight);";
           
        private const String ERROR_ADDING_FOOD_TO_MEAL = "Error! Check if is valid add this new food {0} to this meal {1}";

        public MealDao(ConnectionPostgres connectionPostgres)
        {
            this.connectionPostgres = connectionPostgres;
        }

        public bool AddMeal(MealEntity meal, User user)
        {
            if (SaveMeal(meal, user))
            {
                return true && AddMealFood(meal.MealFoods, meal);
            }
            else
            {
                return false;
            }
        }

        public bool AddMealFood(List<MealFood> mealFoods, MealEntity meal)
        {
            bool resultado = false;
            foreach (MealFood mealFood in mealFoods)
            {
                resultado = SaveNewMealFood(mealFood, meal);
                if (!resultado)
                {
                    throw new Exception(String.Format(ERROR_ADDING_FOOD_TO_MEAL, mealFood.Food.FoodID, mealFood.Meal.MealID));
                }
            }

            return resultado;
        }

        public List<MealEntity> GetAllMealsFromUser(User user)
        {
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(String.Format(SELECT_ALL_MEALS_FROM_USER, user.Name), con);
            NpgsqlDataReader dr = command.ExecuteReader();
            List<MealEntity> listMeal = new List<MealEntity>();
            while (dr.Read())
            {
                MealEntity meal = new MealEntity() { MealID = int.Parse(dr[0].ToString()), MealDate = DateTime.Parse(dr[2].ToString()) };
                meal.MealFoods = GetMealFoods(meal);
                listMeal.Add(meal);
            }
            con.Close();
            return listMeal;
        }

        public List<MealFood> GetMealFoods(MealEntity meal)
        {
            List<MealFood> mealFoods = new List<MealFood>();
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(String.Format(SELECT_ALL_MEAL_FOOD, meal.MealID), con);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                string teste = dr[0].ToString();
                mealFoods.Add(new MealFood()
                {
                    Meal = meal,
                    Food = new FoodEntity()
                    {
                        FoodID = int.Parse(dr[3].ToString()),
                        Name = dr[4].ToString(),
                        Amount = double.Parse(dr[5].ToString()),
                        Calories = double.Parse(dr[6].ToString()),
                        Carbs = double.Parse(dr[7].ToString()),
                        Fat = double.Parse(dr[8].ToString()),
                        Protein = double.Parse(dr[9].ToString())
                    },
                    Amount = int.Parse(dr[1].ToString()),
                    Weigth = dr[2].ToString()
                });

            }
            con.Close();

            return mealFoods;
        }

        public int GetNextId()
        {
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(SELECT_NEXT_ID, con);
            NpgsqlDataReader dr = command.ExecuteReader();
            int nextValue = 0;
            if (dr.Read())
            {
                nextValue = dr[0].ToString() == string.Empty ? 1 : int.Parse(dr[0].ToString());
            }

            con.Close();
            return nextValue;
        }        

        private bool SaveMeal(MealEntity meal, User user)
        {
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(INSERT_INTO_MEAL, con);
            command.Parameters.AddWithValue(":id", meal.MealID);
            command.Parameters.AddWithValue(":username", user.Name);
            command.Parameters.AddWithValue(":date_meal", meal.MealDate.ToString("dd/MM/yyyy HH:mm:ss"));
            bool value = (command.ExecuteNonQuery() > 0);
            con.Close();
            return value;
        }

        private bool SaveNewMealFood(MealFood mealFood, MealEntity meal)
        {
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(INSERT_INTO_MEAL_FOOD, con);
            command.Parameters.AddWithValue(":id_meal", meal.MealID);
            command.Parameters.AddWithValue(":id_food", mealFood.Food.FoodID);
            command.Parameters.AddWithValue(":amount", mealFood.Amount);
            command.Parameters.AddWithValue(":weight", mealFood.Weigth);
            bool value = (command.ExecuteNonQuery() > 0);
            con.Close();
            return value;
        }       
    }
}