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
        private ConnectionPostgres connection;
        private const String SELECT_ALL_MEALS_FROM_USER = "select m.id, m.username, m.date_meal from meal m where m.username = '{0}'";
        private const String SELECT_ALL_FOODS_FROM_MEAL = "select m.id, m.username, m.date_meal, f.id, f.amout, f.name, f.calories, f.carbs, f.fat, f.protein from meal m inner join meal_food mf on mf.id_meal = m.id inner join food f on f.id = mf.id_food where m.username = {0} ";

        public MealDao(ConnectionPostgres connection)
        {
            this.connection = connection;
        }

        public List<Meal> GetAllMealsFromUser(User user)
        {
            NpgsqlConnection con = connection.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(String.Format(SELECT_ALL_MEALS_FROM_USER, user.Name), con);
            NpgsqlDataReader dr = command.ExecuteReader();
            List<Meal> listMeal = new List<Meal>();
            while (dr.Read())
            {
                listMeal.Add(new Meal() { MealID = int.Parse(dr[0].ToString()) });
            }
            con.Close();
            return listMeal;
        }

    }
}
