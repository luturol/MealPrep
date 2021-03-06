﻿using MealPrep.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Model
{
    public class TitleFactory
    {
        private static readonly string TITLE_NEW_FOOD = "New Food";
        private static readonly string TITLE_NEW_MEAL = "New Meal";
        private static readonly string TITLE_NEW_VITAMIN = "New Vitamin";
        private static readonly String ERROR_TITLE_NOT_FOUND = "Title not found";        
        
        public static string GetTitle(Type type)
        {
            if (type.Equals(typeof(ucAddFood)))
            {
                return TITLE_NEW_FOOD;
            }
            else if(type.Equals(typeof(ucAddMeal)))
            {
                return TITLE_NEW_MEAL;
            }
            else if (type.Equals(typeof(ucAddVitamin)))
            {
                return TITLE_NEW_VITAMIN;
            }
            else
            {
                throw new Exception(ERROR_TITLE_NOT_FOUND);
            }
        }
    }
}
