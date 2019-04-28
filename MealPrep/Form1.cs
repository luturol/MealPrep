using System.Windows.Forms;
using MealPrep.Connection;
using MealPrep.Login.Controller;
using MealPrep.Login.Repository;
using MealPrep.Login.View;
using MealPrep.Utils;

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
            this.Controls.Add(new ucLoginPage());
            UsefulAlgorithms.AdjustFormSize(this);
        }        
    }
}
