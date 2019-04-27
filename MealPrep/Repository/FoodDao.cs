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
    public class FoodDao : IFoodDao
    {
        private ConnectionPostgres connectionPostgres;
        private const string INSERT_INTO_FOOD = "insert into food(id, name, amount, calories, carbs, protein, fat) values(:id, :name, :amount, :calories, :carbs, :protein, :fat);";
        private const string SELECT_ALL_FOODS = "select * from food;";
        private const string SELECT_NEXT_ID = "select max(id) + 1 from food;";
        private const String INSERT_INTO_FOOD_VITAMINS = "insert into food_vitamins(id_food, id_vitamin, amount, weight) values(:id_food, :id_vitamins, :amount, :weight);";
        private const String ERROR_ADDING_VITAMIN_TO_FOOD = "Error! Check if is valid add this new vitamin {0} to this food {1}";

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

        public bool AddFoodVitamin(List<FoodVitamin> foodVitamins)
        {
            bool resultado = false;
            foreach(FoodVitamin foodVitamin in foodVitamins)
            {
                resultado = SaveNewFoodVitamin(foodVitamin);
                if (!resultado)
                {
                    throw new Exception(String.Format(ERROR_ADDING_VITAMIN_TO_FOOD, foodVitamin.Vitamin.VitaminID, foodVitamin.Food.FoodID));
                }
            }

            return resultado;
        }

        private bool SaveNewFoodVitamin(FoodVitamin foodVitamin)
        {
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(INSERT_INTO_FOOD_VITAMINS, con);
            command.Parameters.AddWithValue(":id_food", foodVitamin.Food.FoodID);
            command.Parameters.AddWithValue(":id_vitamins", foodVitamin.Vitamin.VitaminID);
            command.Parameters.AddWithValue(":amount", foodVitamin.Amount);
            command.Parameters.AddWithValue(":weight", foodVitamin.Weigth);
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
            NpgsqlCommand command = new NpgsqlCommand(SELECT_NEXT_ID, con);
            NpgsqlDataReader dr = command.ExecuteReader();
            int nextValue = 1;
            if (dr.Read())
                nextValue = int.Parse(dr[0].ToString());
            con.Close();
            return nextValue;
        }
    }
}
