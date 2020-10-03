using CafeChallenge_Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CafeChallenge_Console
{
    class ProgramUI
    {
        private CafeRepository _menuRepo = new CafeRepository();

        //Method that runs the application
        public void Run()
        {
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool runProgram = true;

            Console.Clear();

            while (runProgram)
            {
                //Show User Options
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add Menu Items\n" +
                    "2. See All Menu Items\n" +
                    "3. See A Single Menu Item\n" +
                    "4. Delete Menu Items\n" +
                    "5. Exit");

                // Read User's Input
                string input = Console.ReadLine();

                //Evaluate and respond to user's input
                switch (input)
                {
                    case "1":
                        //Create item
                        CreateNewItem();
                        break;
                    case "2":
                        //View all items
                        ViewCurrentMenuItems();
                        break;
                    case "3":
                        //Vew single item
                        ViewSingleMenuItem();
                        break;
                    case "4":
                        //Delete item
                        DeleteMenuItem();
                        break;
                    case "5":
                        //Exit
                        runProgram = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }
        //Create new menu item
        private void CreateNewItem()
        {
            Console.Clear();

            Cafe newItem = new Cafe();
            CafeRepository menu = new CafeRepository();
            
            //Meal Number
             
            Console.WriteLine("Please enter the item/meal number:");

            string input = Console.ReadLine();
            int number;
            bool isNumber = Int32.TryParse(input, out number);
            if (isNumber == true)
            {
                newItem.MealNumber = number;
            }
            else
            {
                Console.WriteLine("Please input a valid number\n" +
                       "Press any key to continue");
                Console.ReadKey();
                CreateNewItem();
            }
            
            //Meal Name
            Console.WriteLine("Please enter the item/meal name:");
            string nameInput = Console.ReadLine().ToLower();
            if(nameInput != null)
            {
                newItem.MealName = nameInput;
            }
            else
            {
                Console.WriteLine("Please input a valid name\n" +
                      "Press any key to continue");
                Console.ReadKey();
                CreateNewItem();
            }

            //Meal Description
            Console.WriteLine("Please enter the item/meal description:");
            newItem.Description = Console.ReadLine().ToLower();
            //Meal Ingredients
            Console.WriteLine("Please enter the item/meal ingredients:");
            string ingredients = Console.ReadLine();
            newItem.AddIngredients(ingredients);
            //Meal Price
            Console.WriteLine("Please enter the item/meal price:");
            
            string priceInput = Console.ReadLine();

            double priceNumber;
            bool isItNumber = double.TryParse(priceInput, out priceNumber);
            if (isItNumber == true)
            {
                newItem.Price = priceNumber;
            }
            else
            {
                Console.WriteLine("Please input a valid number\n" +
                       "Press any key to continue");
                Console.ReadKey();
            }
            _menuRepo.AddMenuItems(newItem);

            Menu();
        }

        //View current menu items
        private void ViewCurrentMenuItems()
        {
            Console.Clear();

            List<Cafe> listOfMenuItems = _menuRepo.GetMenuItems();

            foreach (Cafe item in listOfMenuItems)
            {
                string writeIngredients = null;
                foreach(string ingredients in item.Ingredients)
                {
                     writeIngredients = ingredients;
                }
                Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredients: {writeIngredients}\n" +
                    $"Price: {item.Price}\n" +
                    $"\n");
            }
        }
        //view a single menu item
        private void ViewSingleMenuItem()
        {
            Console.Clear();

            Console.WriteLine("Please enter the meal name or number:");

            string input = Console.ReadLine();

            int singleNum;

            bool isItNumber = Int32.TryParse(input, out singleNum);


            if (isItNumber == true)
            {
                Cafe item = _menuRepo.GetItemsByNumber(singleNum);
                if(item != null)
                {
                    string writeIngredients = null;
                    foreach (string ingredients in item.Ingredients)
                    {
                        writeIngredients = ingredients;
                    }
                    Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredients: {writeIngredients}\n" +
                    $"Price: {item.Price}\n" +
                    $"\n");
                }
                else
                {
                    Console.WriteLine("There was no meal attributed to that number. \n");
                }
            }
            else
            {
                Cafe item = _menuRepo.GetItemsByName(input);
                if (item != null)
                {
                    string writeIngredients = null;
                    foreach (string ingredients in item.Ingredients)
                    {
                        writeIngredients = ingredients;
                    }
                    Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredients: {writeIngredients}\n" +
                    $"Price: {item.Price}\n" +
                    $"\n");
                }
                else
                {
                    Console.WriteLine("There was no meal attributed to that number. \n");
                }
            }

        }
        //Delete a menu item
        private void DeleteMenuItem()
        {
            Console.Clear();

            ViewCurrentMenuItems();

            Console.WriteLine("Please enter the meal name or number you wish to delete");

            string input = Console.ReadLine();

            int singleNum;

            bool isItNumber = Int32.TryParse(input, out singleNum);

            if (isItNumber == true)
            {
                Cafe item = _menuRepo.GetItemsByNumber(singleNum);
                if (item != null)
                {
                    string writeIngredients = null;
                    foreach (string ingredients in item.Ingredients)
                    {
                        writeIngredients = ingredients;
                    }
                    Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredients: {writeIngredients}\n" +
                    $"Price: {item.Price}\n" +
                    $"\n" +
                    $"Are you sure you wish to delete this item? Y or N");
                    string response = Console.ReadLine().ToLower();
                    if (response == "y")
                    {
                        _menuRepo.RemoveItemByNumber(item.MealNumber);
                    }
                    else{
                        Console.WriteLine("You have selected not to delete this item\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        Menu();
                    }
                }
                else
                {
                    Console.WriteLine("There was no meal attributed to that number. \n" +
                        "Press any key to continue");
                    Console.ReadKey();
                    Menu();
                }
            }
            else
            {
                Cafe item = _menuRepo.GetItemsByName(input);
                if (item != null)
                {
                    Console.WriteLine($"Meal Number: {item.MealNumber}\n" +
                    $"Meal Name: {item.MealName}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredients: {item.Ingredients}\n" +
                    $"Price: {item.Price}\n" +
                    $"\n" +
                    $"Are you sure you wish to delete this item? Y or N");
                    string response = Console.ReadLine().ToLower();
                    if (response == "y")
                    {
                        _menuRepo.RemoveItemByName(item.MealName);
                    }
                    else
                    {
                        Console.WriteLine("You have selected not to delete this item\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        Menu();
                    }
                }
                else
                {
                    Console.WriteLine("There was no meal attributed to that name. \n" +
                        "Press any key to continue");
                    Console.ReadKey();
                    Menu();
                }
            }


        }

        //See method
        private void SeedMenuList()
        {
            //Cafe grilledcheese = new Cafe(1, "jt's grilled cheese", "3 curated cheeses, grilled to perfection on our homemade sourdough bread", new List<string>, )
        }
    }
}
