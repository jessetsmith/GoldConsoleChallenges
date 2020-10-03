using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeConsole_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateMenuItem()
        {
            List<string> ingredients = new List<string>
            {
                "Cheese, Bread, butter"
            };

            CafeChallenge_Repository.Cafe newCafe = new CafeChallenge_Repository.Cafe(1, "Grilled Cheese", "A great grilled cheese", ingredients, 5.50);

            CafeChallenge_Repository.CafeRepository _cafeRepo = new CafeChallenge_Repository.CafeRepository();

            _cafeRepo.AddMenuItems(newCafe);

            Console.WriteLine($"{newCafe.MealName}");
        }

        [TestMethod]
        public void TestViewMenuItems()
        {
            List<string> ingredients = new List<string>
            {
                "Cheese, Bread, butter"
            };

            CafeChallenge_Repository.Cafe newCafe = new CafeChallenge_Repository.Cafe(1, "Grilled Cheese", "A great grilled cheese", ingredients, 5.50);

            CafeChallenge_Repository.CafeRepository newCafeRepo = new CafeChallenge_Repository.CafeRepository();

            newCafeRepo.AddMenuItems(newCafe);

            newCafeRepo.GetMenuItems();
        }

        [TestMethod]
        public void TestRemoveItemByNumber()
        {

            List<string> ingredients = new List<string>
            {
                "Cheese, Bread, butter"
            };

            CafeChallenge_Repository.Cafe newCafe = new CafeChallenge_Repository.Cafe(1, "Grilled Cheese", "A great grilled cheese", ingredients, 5.50);
            CafeChallenge_Repository.CafeRepository _cafeRepo = new CafeChallenge_Repository.CafeRepository();

            _cafeRepo.AddMenuItems(newCafe);

            _cafeRepo.RemoveItemByNumber(newCafe.MealNumber);
        }

        [TestMethod]
        public void TestRemoveItemByName()
        {
            List<string> ingredients = new List<string>
            {
                "Cheese, Bread, butter"
            };

            CafeChallenge_Repository.Cafe newCafe = new CafeChallenge_Repository.Cafe(1, "Grilled Cheese", "A great grilled cheese", ingredients, 5.50);
            CafeChallenge_Repository.CafeRepository _cafeRepo = new CafeChallenge_Repository.CafeRepository();

            _cafeRepo.AddMenuItems(newCafe);

            _cafeRepo.RemoveItemByName(newCafe.MealName);
        }
    }
}
