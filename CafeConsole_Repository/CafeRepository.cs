using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeChallenge_Repository
{
    public class CafeRepository
    {

        public List<Cafe> _menuItems = new List<Cafe>();

        //Create
        public void AddMenuItems(Cafe items)
        {
            _menuItems.Add(items);
        }
        //Read
        public List<Cafe> GetMenuItems()
        {
            return _menuItems;
        }

        ////Update
        //public bool UpdateMenuItems(string originalItemName, int originalItemNumber, Cafe newItem)
        //{
        //    //Find the item
        //    Cafe oldItem = GetItemsByNameOrNumber(originalItemNumber, originalItemName);

        //    //Update the item
        //    if (oldItem != null)
        //    {
        //        oldItem.MealName = newItem.MealName;
        //        oldItem.MealNumber = newItem.MealNumber;
        //        oldItem.Description = newItem.Description;
        //        oldItem.Ingredients = newItem.Ingredients;
        //        oldItem.Price = newItem.Price;

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //Delete
        public bool RemoveItemByNumber(int mealNumber)
        {
            Cafe item = GetItemsByNumber(mealNumber);

            if (item == null)
            {
                return false;
            }

            int initalCount = _menuItems.Count;
            _menuItems.Remove(item);

            if (initalCount > _menuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveItemByName(string mealName)
        {
            Cafe item = GetItemsByName(mealName);

            if (item == null)
            {
                return false;
            }

            int initalCount = _menuItems.Count;
            _menuItems.Remove(item);

            if (initalCount > _menuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Helper methods
        public Cafe GetItemsByName(string name)
        {
            foreach (Cafe item in _menuItems)
            {
                if (item.MealName == name)
                {
                    return item;
                }
            }

            return null;
        }

        public Cafe GetItemsByNumber(int number)
        {
            foreach (Cafe item in _menuItems)
            {
                if (item.MealNumber == number)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
