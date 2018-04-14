using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MealPrep.Dao;
using Npgsql;

namespace MealPrep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            testaBD();
        }

        private void Initialize()
        {
            BusinessLayer business = new BusinessLayer("127.0.0.1", "5432", "postgres", "a.123456", "mealprep");

        }

        private void testaBD()
        {
            try
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                // PostgeSQL-style connection string
                string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    "127.0.0.1", "5432", "postgres",
                    "a.123456", "mealprep");
                // Making connection with Npgsql provider
                NpgsqlConnection conn = new NpgsqlConnection(connstring);
                conn.Open();
                // quite complex sql statement
                string sql = "SELECT * FROM meal";
                // data adapter making request from our connection
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                // i always reset DataSet before i do
                // something with it.... i don't know why :-)
                ds.Reset();
                // filling DataSet with result from NpgsqlDataAdapter
                da.Fill(ds);
                // since it C# DataSet can handle multiple tables, we will select first
                dt = ds.Tables[0];
                // connect grid to DataTable
               
                // since we only showing the result we don't need connection anymore
                conn.Close();
            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show(msg.ToString());
                throw;
            }
        }
    }
}
