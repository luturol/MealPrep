using MealPrep.Connection;
using MealPrep.Login.Interfaces;
using MealPrep.Login.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Login.Repository
{
    public class UserDao : IUserDao
    {
        private ConnectionPostgres connection;
        private const String INSERT_INTO_USER_MEAL = "INSERT INTO USER_MEAL(USERNAME, USER_PASSWORD, DATE_ADD) VALUES (:username, :password, :date);";
        private const String SELECT_ALL_USERS = "SELECT * FROM USER_MEAL;";

        public UserDao(ConnectionPostgres connection)
        {
            this.connection = connection;
        }

        public bool AddUser(User user)
        {
            NpgsqlConnection con = connection.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(INSERT_INTO_USER_MEAL, con);
            command.Parameters.AddWithValue(":username", user.Name);
            command.Parameters.AddWithValue(":password", user.Password);
            command.Parameters.AddWithValue(":date", DateTime.Now);
            bool value = (command.ExecuteNonQuery() > 0);
            con.Close();
            return value;
        }

        public List<User> GetAllUsers()
        {
            NpgsqlConnection con = connection.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(SELECT_ALL_USERS, con);
            NpgsqlDataReader dr = command.ExecuteReader();
            List<User> listUsers = new List<User>();
            while (dr.Read())
            {
                listUsers.Add(new User(dr[0].ToString(), dr[1].ToString()));
            }
            con.Close();
            return listUsers;
        }
    }
}
