using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Model
{
    public class MealFood
    {
        public int FoodID { get; set; }
        public int MealID { get; set; }
        public double Amount { get; set; }
        public string Weigth { get; set; }
    }
}
