using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Model
{
    public class Meal
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }        
        public List<Food> Foods { get; set; }
    }
}
