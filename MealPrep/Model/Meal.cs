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
        public DateTime MealDate { get; set; }
        public User User { get; set; }        
        public List<MealFood> MealFoods { get; set; }
    }
}
