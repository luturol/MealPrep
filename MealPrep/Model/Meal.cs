using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Model
{
    public class Meal
    {
        public int MealID { get; set; }
        public List<Food> Foods { get; set; }        

    }
}
