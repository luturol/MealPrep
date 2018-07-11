using MealPrep.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Dao
{
    public class FoodDao
    {
        private ConnectionPostgres connectionPostgres;
        private const string INSERT_INTO_FOOD = "insert into food(id, name, amount, calories, carbs, protein, fat) values(:id, :name, :amount, :calories, :carbs, :protein, :fat);";
        private const string SELECT_ALL_FOODS = "select * from foods;";
        private const string SELECT_NEXT_ID = "selext max(id) + 1 from food;";

        public FoodDao(ConnectionPostgres connectionPostgres)
        {
            this.connectionPostgres = connectionPostgres;
        }

        public bool AddFood(Food food)
        {
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(INSERT_INTO_FOOD, con);
            command.Parameters.AddWithValue(":id", food.FoodID);
            command.Parameters.AddWithValue(":name", food.Name);
            command.Parameters.AddWithValue(":amount", food.Amount);
            command.Parameters.AddWithValue(":calories", food.Calories);
            command.Parameters.AddWithValue(":carbs", food.Carbs);
            command.Parameters.AddWithValue(":protein", food.Protein);
            command.Parameters.AddWithValue(":fat", food.Fat);
            bool value = (command.ExecuteNonQuery() > 0);
            con.Close();
            return value;
        }

        public List<Food> GetAllFoods()
        {
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(SELECT_ALL_FOODS, con);
            NpgsqlDataReader dr = command.ExecuteReader();
            List<Food> listFood = new List<Food>();
            while (dr.Read())
            {
                listFood.Add(new Food()
                {
                    FoodID = int.Parse(dr[0].ToString()),
                    Name = dr[1].ToString(),
                    Amount = double.Parse(dr[2].ToString()),
                    Calories = double.Parse(dr[3].ToString()),
                    Carbs = double.Parse(dr[4].ToString()),
                    Protein = double.Parse(dr[5].ToString()),
                    Fat = double.Parse(dr[6].ToString())
                });

            }
            con.Close();
            return listFood;
        }

        public int GetNextID()
        {
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(SELECT_ALL_FOODS, con);
            NpgsqlDataReader dr = command.ExecuteReader();
            con.Close();
            return int.Parse(dr[0].ToString());                                    
        }
    }
}
