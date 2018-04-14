using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Dao
{
    public class BusinessLayer
    {
        private const String connstring = "Server={0};Port={1}; User Id={2};Password={3};Database={4};";
        private String server;
        private String port;
        private String user;
        private String password;
        private String database;


        public BusinessLayer(String server, String port, String user, String password, String database)
        {
            this.server = server;
            this.port = port;
            this.user = user;
            this.password = password;
            this.database = database;
        }

        public DataTable ExecuteSQLWithDataTableReturn(String sql)
        {
            DataSet ds = new DataSet();
            NpgsqlConnection pgsqlConnection = GetConnection();
            pgsqlConnection.Open();
            NpgsqlDataAdapter pgsqlDataAdapter = new NpgsqlDataAdapter(sql, pgsqlConnection);
            ds.Reset();
            pgsqlDataAdapter.Fill(ds);
            pgsqlConnection.Close();

            return ds.Tables[0];
        }

        private NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(String.Format(connstring, server, port, user, password, database));
        }

        private NpgsqlDataAdapter GetDataAdapter(String sql, NpgsqlConnection connection)
        {
            return new NpgsqlDataAdapter(sql, connection);
        }
    }
}
