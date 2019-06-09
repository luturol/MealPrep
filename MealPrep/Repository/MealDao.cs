using MealPrep.Interfaces;
using MealPrep.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Repository
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

        public bool AddMeal(Meal meal)
        {
            if (SaveMeal(meal))
            {
                return true && AddMealFood(meal);
            }
            else
            {
                return false;
            }
        }

        public bool AddMealFood(Meal meal)
        {
            bool resultado = false;
            foreach (Food food in meal.Foods)
            {
                resultado = SaveNewMealFood(food, meal.Id);
                if (!resultado)
                {
                    throw new Exception(String.Format(ERROR_ADDING_FOOD_TO_MEAL, food.FoodID, meal.Id));
                }
            }

            return resultado;
        }

        public List<Meal> GetAllMealsFromUser(User user)
        {
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(String.Format(SELECT_ALL_MEALS_FROM_USER, user.Name), con);
            NpgsqlDataReader dr = command.ExecuteReader();
            List<Meal> listMeal = new List<Meal>();
            while (dr.Read())
            {
                Meal meal = new Meal() { Id = int.Parse(dr[0].ToString()), Date = DateTime.Parse(dr[2].ToString()) };
                meal.Foods = GetMealFoods(meal);
                listMeal.Add(meal);
            }
            con.Close();
            return listMeal;
        }

        public List<Food> GetMealFoods(Meal meal)
        {
            List<Food> mealFoods = new List<Food>();
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(String.Format(SELECT_ALL_MEAL_FOOD, meal.Id), con);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                string teste = dr[0].ToString();
                mealFoods.Add(new Food()
                {
                    FoodID = int.Parse(dr[3].ToString()),
                    Name = dr[4].ToString(),
                    Amount = double.Parse(dr[5].ToString()),
                    Calories = double.Parse(dr[6].ToString()),
                    Carbs = double.Parse(dr[7].ToString()),
                    Fat = double.Parse(dr[8].ToString()),
                    Protein = double.Parse(dr[9].ToString())
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

        private bool SaveMeal(Meal meal)
        {
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(INSERT_INTO_MEAL, con);
            command.Parameters.AddWithValue(":id", meal.Id);
            command.Parameters.AddWithValue(":username", meal.User.Name);
            command.Parameters.AddWithValue(":date_meal", meal.Date.ToString("dd/MM/yyyy HH:mm:ss"));
            bool value = (command.ExecuteNonQuery() > 0);
            con.Close();
            return value;
        }

        private bool SaveNewMealFood(Food food, int mealID)
        {
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(INSERT_INTO_MEAL_FOOD, con);
            command.Parameters.AddWithValue(":id_meal", mealID);
            command.Parameters.AddWithValue(":id_food", food.FoodID);
            command.Parameters.AddWithValue(":amount", food.Amount);
            command.Parameters.AddWithValue(":weight", "g");
            bool value = (command.ExecuteNonQuery() > 0);
            con.Close();
            return value;
        }
    }
}
