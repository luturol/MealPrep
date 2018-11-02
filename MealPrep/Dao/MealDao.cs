using MealPrep.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Dao
{
    public class MealDao
    {
        private ConnectionPostgres connectionPostgres;
        private const String SELECT_ALL_MEALS_FROM_USER = "select m.id, m.username, m.date_meal from meal m where m.username = '{0}'";
        private const String SELECT_ALL_FOODS_FROM_MEAL = "select m.id, m.username, m.date_meal, f.id, f.amout, f.name, f.calories, f.carbs, f.fat, f.protein from meal m inner join meal_food mf on mf.id_meal = m.id inner join food f on f.id = mf.id_food where m.username = {0} ";
        private const String SELECT_NEXT_ID = "select max(m.id) + 1 as nextid from meal m;";
        private const String SELECT_ALL_MEAL_FOOD = "select m.* from meal_food m;";
        private const String INSERT_INTO_MEAL = "insert into meal(id, username, date_meal) values(:id, :username, to_timestamp(:date_meal, 'dd-mm-yyyy hh24:mi:ss'));";
        private const String INSERT_INTO_MEAL_FOOD = "insert into meal_food(id_meal, id_food, amount, weight) values(:id_meal, :id_food, :amount, :weight);";
           
        private const String ERROR_ADDING_FOOD_TO_MEAL = "Error! Check if is valid add this new food {0} to this meal {1}";

        public MealDao(ConnectionPostgres connectionPostgres)
        {
            this.connectionPostgres = connectionPostgres;
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
                listMeal.Add(new Meal() { MealID = int.Parse(dr[0].ToString()), MealDate = DateTime.Parse(dr[2].ToString()) });
            }
            con.Close();
            return listMeal;
        }

        public bool AddMeal(Meal meal, User user)
        {
            if(SaveMeal(meal, user))
            {
                return true && AddMealFood(meal.MealFoods);
            }
            else
            {
                return false;
            }
        }

        private bool SaveMeal(Meal meal, User user)
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

        public bool AddMealFood(List<MealFood> mealFoods)
        {
            bool resultado = false;
            foreach (MealFood mealFood in mealFoods)
            {
                resultado = SaveNewMealFood(mealFood);
                if (!resultado)
                {
                    throw new Exception(String.Format(ERROR_ADDING_FOOD_TO_MEAL, mealFood.FoodID, mealFood.MealID));
                }
            }

            return resultado;
        }

        private bool SaveNewMealFood(MealFood mealFood)
        {
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(INSERT_INTO_MEAL_FOOD, con);
            command.Parameters.AddWithValue(":id_meal", mealFood.MealID);
            command.Parameters.AddWithValue(":id_food", mealFood.FoodID);
            command.Parameters.AddWithValue(":amount", mealFood.Amount);
            command.Parameters.AddWithValue(":weight", mealFood.Weigth);
            bool value = (command.ExecuteNonQuery() > 0);
            con.Close();
            return value;
        }

        public List<MealFood> GetMealFoods()
        {
            List<MealFood> mealFoods = new List<MealFood>();
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(SELECT_ALL_MEAL_FOOD, con);
            NpgsqlDataReader dr = command.ExecuteReader();            
            while (dr.Read())
            {
                mealFoods.Add(new MealFood() { MealID = int.Parse(dr[0].ToString()),
                FoodID = int.Parse(dr[1].ToString()),
                Amount = int.Parse(dr[2].ToString()),
                Weigth = dr[3].ToString()
                });
            }
            con.Close();
            return mealFoods;
        }
    }
}
