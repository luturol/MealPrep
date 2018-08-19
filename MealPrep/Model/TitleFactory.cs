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
        private static readonly String TITLE_NEW_VITAMIN = "New Vitamin";
        private static readonly String TITLE_PROGRESS_BAR = "Loading..";
        private static readonly String ERROR_TITLE_NOT_FOUND = "Title not found";        
        
        public static String GetTitle(Type type)
        {
            if (type.Equals(typeof(ucAddFood)))
            {
                return TITLE_NEW_FOOD;
            }
            else if (type.Equals(typeof(ucAddVitamin)))
            {
                return TITLE_NEW_VITAMIN;
            }
            else if (type.Equals(typeof(ucProgressBar)))
            {
                return TITLE_PROGRESS_BAR;
            }
            else
            {
                throw new Exception(ERROR_TITLE_NOT_FOUND);
            }
        }
    }
}
