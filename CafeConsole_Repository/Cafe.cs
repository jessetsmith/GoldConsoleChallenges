using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeChallenge_Repository
{
    public class Cafe
    {
        public List<string> _ingredients = new List<string>();

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients 
        { 
            get 
            { return _ingredients; }
            set { }
        }

        public void AddIngredients(string ing)
        {
           _ingredients.Add(ing);
            List<string> addIng = _ingredients;
            Ingredients = addIng;
        }
        public double Price { get; set; }


        public Cafe() { }

        public Cafe(int mealNumber, string mealName, string description, List<string> ingredients, double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;

        }
    }


}
