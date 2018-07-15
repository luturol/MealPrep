using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MealPrep.Controller;
using MealPrep.Dao;
using MealPrep.Useful;
using MealPrep.View;
using Npgsql;

namespace MealPrep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            ConnectionPostgres conn = new ConnectionPostgres("127.0.0.1", "5432", "postgres", "a.123456", "mealprep");
            UserController userController = new UserController(new UserDao(conn));
            MealController mealController = new MealController(new MealDao(conn));
            this.Controls.Add(new ucLoginPage(userController, mealController));
            UsefulAlgorithms.AdjustFormSize(this);
        }        
    }
}
