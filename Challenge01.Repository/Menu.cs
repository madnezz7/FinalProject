using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge01.Repository;

namespace Challenge01.Repository
{
    public class MenuItem
    {
        // Class Object of Menu

        //Property

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealIngredients { get; set; }
        public decimal MealPrice { get; set; }

        //Full Constructor
        public MenuItem(int mealNumber, string mealName, string mealDescription, string mealIngredients, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            MealPrice = mealPrice;
        }


    }

}