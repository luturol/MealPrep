using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Model
{
    public class MealFood
    {
        public Food Food { get; set; }
        public Meal Meal { get; set; }
        public double Amount { get; set; }
        public string Weigth { get; set; }
    }
}
