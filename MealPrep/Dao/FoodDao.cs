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
        private const string INSERT_INTO_FOOD = "insert into food(id, name, amount, calories, carbs, protein, fat) values(:id, :name, :amount, :calories, :carbs, :protein, :fat)";

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
    }
}
