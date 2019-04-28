using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Food.Model
{
    public class FoodVitamin
    {
        public FoodEntity Food { get; set; }        
        public Vitamin Vitamin { get; set; }
        public double Amount { get; set; }
        public string Weigth { get; set; }
    }
}
