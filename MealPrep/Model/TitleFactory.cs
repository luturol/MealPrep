using MealPrep.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Model
{
    public class TitleFactory
    {
        private static readonly String TITLE_NEW_FOOD = "New Food";
        private static readonly String ERROR_TITLE_NOT_FOUND = "Title not found";

        public static String GetTitle(Type type)
        {
            if (type.Equals(typeof(ucAddFood)))
            {
                return TITLE_NEW_FOOD;
            }
            else
            {
                throw new Exception(ERROR_TITLE_NOT_FOUND);
            }
        }
    }
}
