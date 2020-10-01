using KomodoBadges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KomodoBadges_Console
{
    class ProgramUI
    {
        private BadgesRepository _badgeRepo = new BadgesRepository();
        
        private List<string> _doorList = new List<string>
        {
            "1E",
            "101",
            "102",
            "103",
            "104",
            "105",
            "2E",
            "201",
            "202",
            "203",
            "204",
            "205",
            "3E",
            "301",
            "302",
            "303",
            "304",
            "305"
        };

        //Method that runs the program
        public void Run()
        {
            Menu();
        }

        //The method that invokes the menu
        private void Menu()
        {
            bool runProgram = true;

            while (runProgram)
            {
                Console.Clear();
                //Show User Options
                Console.WriteLine("Good day, security Admin\n" +
                    "\n" +
                    "Select a menu option:\n" +
                    "1. Create a new badge\n" +
                    "2. Edit an existing badge\n" +
                    "3. View all active badges\n" +
                    "4. Exit");

                //Read User's input
                string input = Console.ReadLine();

                //Evaluate and respond to user's input
                switch (input)
                {
                    case "1":
                        //Create new badge
                        CreateNewBadge();
                        break;
                    case "2":
                        //Edit a badge
                        EditBadge();
                        break;
                    case "3":
                        //Vew active badges
                        ViewActiveBadges();
                        break;
                    case "4":
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
        //Create new badge
        private void CreateNewBadge()
        {
            
            Badges newBadge = new Badges();

            //BadgeID
            Console.WriteLine("Please enter the badge ID:");
            string input = Console.ReadLine();
            int number;
            bool isNumber = Int32.TryParse(input, out number);
            if (isNumber == true)
            {
                newBadge.BadgeID = number;
            }
            else
            {
                Console.WriteLine("Please input a valid number\n" +
                       "Press any key to continue");
                Console.ReadKey();
                CreateNewBadge();
            }

            //Add door names

            //List all doors
            Console.WriteLine("Doors available to assign:");

            foreach (string doors in _doorList)
            {
                Console.WriteLine(doors);
            }

            bool doorAssignment = true;
            while (doorAssignment)
            {
                Console.WriteLine("Please input the doors to be assigned to this badge one at a time:");

                string doorInput = Console.ReadLine();

                if (_doorList.Contains(doorInput))
                {
                    newBadge.AddDoorNames(doorInput);
                    Console.WriteLine("Do you wish to add another door assignment?\n" +
                        "Y or N");
                    string yesOrNo = Console.ReadLine().ToLower();
                    if(yesOrNo == "y")
                    {
                        doorAssignment = true;
                    }
                    else if(yesOrNo == "n")
                    {
                        doorAssignment = false;
                    }
                }
                else
                {
                    Console.WriteLine("There is no door matching that input. Please try again.");
                }
            }

            Console.WriteLine("Please input the employee's name for this badge:");

            bool nameAssignment = true;
            while (nameAssignment)
            {
                string nameInput = Console.ReadLine().ToUpper();
                if (nameInput != null)
                {

                    newBadge.NameOnBadge = nameInput;
                    nameAssignment = false;
                }
                else
                {
                    Console.WriteLine("Please input a valid name:\n" +
                        "Press any key to continue");
                    Console.ReadKey();
                }


            }

            _badgeRepo.AddBadges(newBadge.BadgeID, newBadge);

        }

        //Edit badge

        private void EditBadge()
        {
            bool isEditing = true;
            while (isEditing)
            {
            //Display active badges
            ViewActiveBadges();

            //Elicit input from user
            Console.WriteLine("\n" +
                "Please input the badge ID you wish to edit:");

            string inputID = Console.ReadLine();
            int number;
            bool isNumber = Int32.TryParse(inputID, out number);
            if (isNumber == true)
            {
                    Badges newBadge = new Badges();
                    Dictionary<int, Badges> _badgeCollection = _badgeRepo.badgeDictionary;

                if (_badgeCollection.ContainsKey(number))
                {
                        Console.Clear();
                    string doorNames = null;
                    foreach (string doors in _badgeCollection[number].DoorNames)
                    {
                        doorNames = doors;
                    }
                    Console.WriteLine($"Badge ID: {_badgeCollection[number].BadgeID}\n" +
                        $"Doors Assigned: {doorNames}\n" +
                        $"Employee:  {_badgeCollection[number].NameOnBadge}" +
                        $"\n" +
                        $"\n" +
                        $"Please choose an edit option:\n" +
                        $"1. Add door assignments\n" +
                        $"2. Remove door assignments\n" +
                        $"3. Remove badge from system\n" +
                        $"4. Return to main menu\n" +
                        $"\n");

                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            //Add doors
                            AddDoors();
                            break;
                        case "2":
                            //Remove doors
                            RemoveDoors();
                            break;
                        case "3":
                                //Delete badge
                                RemoveBadge();
                                break;
                        case "4":
                                //Main menu
                                isEditing = false;
                                Menu();
                                break;
                        default:
                            Console.WriteLine("Please enter a valid option");
                            break;
                    }
                    void AddDoors()
                    {
                        //List all doors
                        Console.WriteLine("Doors available to assign:");

                        foreach (string doors in _doorList)
                        {
                            Console.WriteLine(doors);
                        }

                        bool doorAssignment = true;
                        while (doorAssignment)
                        {
                            Console.WriteLine("Please input the doors to be assigned to this badge one at a time:");

                            string doorInput = Console.ReadLine();

                            if (_doorList.Contains(doorInput))
                            {
                                Badges oldBadge = _badgeCollection[number];

                                    oldBadge.AddDoorNames(doorInput);
                                    newBadge = oldBadge;
                                    bool wasUpdated = _badgeRepo.UpdateBadges(oldBadge.BadgeID, newBadge);
                                    if (wasUpdated == true)
                                    {
                                        Console.WriteLine("Badge successfully updated!");
                                        Console.WriteLine("Do you wish to add another door assignment?\n" +
                                   "Y or N");
                                        string yesOrNo = Console.ReadLine().ToLower();
                                        if (yesOrNo == "y")
                                        {
                                            doorAssignment = true;
                                        }
                                        else if (yesOrNo == "n")
                                        {
                                            doorAssignment = false;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Could not update badge.");
                                        doorAssignment = false;

                                    }


                                }
                            else
                            {
                                Console.WriteLine("There is no door matching that input. Please try again.");
                            }
                        }
                       
                    }
                    void RemoveDoors()
                    {
                            bool doorRemoval = true;
                            while (doorRemoval)
                            {
                                Console.WriteLine("Please input the doors to be removed one at time:");

                                string doorInput = Console.ReadLine();

                                if (_doorList.Contains(doorInput))
                                {
                                    Badges oldBadge = _badgeCollection[number];

                                    newBadge = oldBadge;

                                    bool wasUpdated = _badgeRepo.RemoveDoorsFromBadge(oldBadge.BadgeID, doorInput);
                                    if (wasUpdated == true)
                                    {
                                        Console.WriteLine("Badge successfully updated!");
                                        Console.WriteLine("Do you wish to remove another door assignment?\n" +
                                   "Y or N");
                                        string yesOrNo = Console.ReadLine().ToLower();
                                        if (yesOrNo == "y")
                                        {
                                            doorRemoval = true;
                                        }
                                        else if (yesOrNo == "n")
                                        {
                                            doorRemoval = false;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Could not update badge.");
                                        doorRemoval = false;

                                    }


                                }
                            }
                    }
                        void RemoveBadge()
                        {
                            bool badgeRemoval = true;
                            while (badgeRemoval)
                            {
                                Console.WriteLine("Are you sure you want to remove this badge from the system?\n" +
                                "Y or N\n" +
                                "\n");

                                string userInput = Console.ReadLine().ToLower();
                                if (userInput == "y")
                                {
                                    Badges oldBadge = _badgeCollection[number];
                                    bool wasRemoved = _badgeRepo.RemoveBadge(oldBadge.BadgeID);
                                    if(wasRemoved == true)
                                    {
                                        Console.WriteLine("Badge successfully removed!\n" +
                                            "Press any key to continue\n" +
                                            "\n");
                                        Console.ReadKey();
                                        badgeRemoval = false;
                                        isEditing = false;
                                        Menu();

                                    }
                                }
                                else
                                {
                                    badgeRemoval = false;
                                }
                            }
                            
                        }
                }
                else
                {
                    Console.WriteLine("There was no badge with that ID. Please input a valid number.\n" +
                    "Press any key to continue");
                    Console.ReadKey();
                    EditBadge();
                }
            }

            else
            {
                Console.WriteLine("We could not find anything based on that input. Please try again with an appropriate number.\n" +
                     "Press any key to continue");
                Console.ReadKey();
                Menu();
            }

            }

        }


        //View all active badges

        private void ViewActiveBadges()
        {
            Console.Clear();

            Dictionary<int, Badges> getBadges = _badgeRepo.GetBadges();

            Dictionary<int, Badges>.ValueCollection values = getBadges.Values;
            
            foreach(Badges badge in values)
            {
                Console.WriteLine($"Badge ID: {badge.BadgeID}\n" +
                    $"Doors Assigned: ");
                string doorNames = null;
                foreach (string doors in badge.DoorNames)
                {
                    doorNames = doors;
                    Console.WriteLine($"| {doorNames} | ");
                }
                Console.WriteLine($"Employee: {badge.NameOnBadge}");
                 
            }
        }


        
       
    }
}
