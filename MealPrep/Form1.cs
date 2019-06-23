using System.Windows.Forms;
using MealPrep.Controller;
using MealPrep.Repository;
using MealPrep.Useful;
using MealPrep.View;

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
            FoodController foodController = new FoodController(new FoodDao(conn));
            MealController mealController = new MealController(new MealDao(conn), new FoodDao(conn));            
            VitaminController vitaminController = new VitaminController(new VitaminDao(conn));
            this.Controls.Add(new ucLoginPage(userController, mealController, foodController, vitaminController));
            UsefulAlgorithms.AdjustFormSize(this);
        }        
    }
}
