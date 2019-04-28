using MealPrep.Connection;
using MealPrep.Food.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Food.Repository
{
    public class VitaminDao
    {
        private ConnectionPostgres connectionPostgres;
        private const string SELECT_ALL_VITAMINS = "select * from vitamins;";
        private const string INSER_INTO_VITAMINS = "insert into vitamins(id, name) values(:id, :name);";

        public VitaminDao(ConnectionPostgres connectionPostgres)
        {
            this.connectionPostgres = connectionPostgres;
        }

        public bool AddVitamin(Vitamin vitamin)
        {
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(INSER_INTO_VITAMINS, con);
            command.Parameters.AddWithValue(":id", vitamin.VitaminID);
            command.Parameters.AddWithValue(":name", vitamin.Name);            
            bool value = (command.ExecuteNonQuery() > 0);
            con.Close();
            return value;
        }

        public List<Vitamin> GetAllVitamins()
        {
            NpgsqlConnection con = connectionPostgres.GetConnection();
            con.Open();
            NpgsqlCommand command = new NpgsqlCommand(SELECT_ALL_VITAMINS, con);
            NpgsqlDataReader dr = command.ExecuteReader();
            List<Vitamin> listVitamins = new List<Vitamin>();
            while (dr.Read())
            {
                listVitamins.Add(new Vitamin() { VitaminID = int.Parse(dr[0].ToString()), Name = dr[1].ToString() });
            }
            con.Close();
            return listVitamins;
        }
    }
}
