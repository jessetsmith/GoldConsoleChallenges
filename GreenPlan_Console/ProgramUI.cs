using GreenPlan_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlan_Console
{
    class ProgramUI
    {
        private CarsRepository _carRepo = new CarsRepository();

        //Runs the program
        public void Run()
        {
           /* Menu();*/
        }

        //Menu

        private void Menu()
        {
            bool runProgram = true;

            while (runProgram)
            {
                //Display our options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add a car to the system\n" +
                    "2. View all cars in the system\n" +
                    "3. View cars by fuel type: electric, hybrid, or gas\n" +
                    "4. Update a car in the system \n" +
                    "5. Delete a car from the system\n" +
                    "6. Exit \n" +
                    "\n");

                //Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Add car 
                        break;
                    case "2":
                        //View all cars
                        break;
                    case "3":
                        //View cars by fuel type
                        break;
                    case "4":
                        //Update a car
                        break;
                    case "5":
                        //Delete a car
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Goodbye");
                        runProgram = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue....");
                Console.ReadKey();
                Console.Clear();
            }
            
  
        }

        //Create a car
        private void CreateCar()
        {
            Console.Clear();

            Cars newCar = new Cars();

            Console.WriteLine("Please enter the make of the car:");
            newCar.Make = Console.ReadLine().ToUpper();
            Console.WriteLine("Please enter the model of the car:");
            newCar.Model = Console.ReadLine().ToUpper();
            Console.WriteLine("Please enter the year the car was released:");
            newCar.Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Please specify the fuel type of the vehicl(electric, hybrid, or gasoline):");
            string fuelInput = Console.ReadLine();
            bool 
            if(fuelInput == )
                

        }



    }
}
