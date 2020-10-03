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
            Menu();
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
                    "3. View cars by model\n" +
                    "4. View cars by fuel type: electric, hybrid, or gas\n" +
                    "5. Update a car in the system \n" +
                    "6. Remove a car from a list or the system\n" +
                    "7. Exit \n" +
                    "\n");

                //Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Add car 
                        CreateCar();
                        break;
                    case "2":
                        //View all cars
                        ViewAllCars();
                        break;
                    case "3":
                        //View all cars
                        ViewCarByModel();
                        break;
                    case "4":
                        //View cars by fuel type
                        ViewCarByFuelType();
                        break;
                    case "5":
                        //Update a car
                        UpdateCar();
                        break;
                    case "6":
                        //Delete a car
                        DeleteCar();
                        break;
                    case "7":
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
            newCar.Make = Console.ReadLine().ToLower();
            Console.WriteLine("Please enter the model of the car:");
            newCar.Model = Console.ReadLine().ToLower();
            Console.WriteLine("Please enter the year the car was released:");
            string input = Console.ReadLine();
            int number;
            bool isNumber = Int32.TryParse(input, out number);
            if (isNumber == true)
            {
                newCar.Year = number;
            }
            else
            {
                Console.WriteLine("Please input a valid number\n" +
                       "Press any key to continue");
                Console.ReadKey();
                CreateCar();
            }

            Console.WriteLine("Please specify the fuel type of the vehicle (electric, hybrid, or gas):");
            string fuelInput = Console.ReadLine().ToLower();
            if (fuelInput == "electric")
            {
                newCar.TypeOfFuel = Cars.FuelType.Electric;
            }
            else if (fuelInput == "hybrid")
            {
                newCar.TypeOfFuel = Cars.FuelType.Hybrid;

            }
            else if (fuelInput == "gas")
            {
                newCar.TypeOfFuel = Cars.FuelType.Gas;

            }

            _carRepo.CreateCar(newCar, newCar.TypeOfFuel);

        }

        //View Cars
        private void ViewAllCars()
        {
            Console.Clear();

            List<Cars> listOfCars = _carRepo.ViewAllCars();

            foreach(Cars car in listOfCars)
            {
                Console.WriteLine($"Make: {car.Make.ToUpper()}\n" +
                    $"Model: {car.Model.ToUpper()}\n" +
                    $"Year: {car.Year}\n" +
                    $"Fuel Type: {car.TypeOfFuel}\n" +
                    $"_______________________");
            }
        }

        private void ViewCarByModel()
        {
            Console.Clear();

            Console.WriteLine("Please enter the model of the car you would like to view:");

            string model = Console.ReadLine();

            Cars car = _carRepo.GetCarByModel(model);

            if(car != null)
            {
                Console.WriteLine($"Make: {car.Make.ToUpper()}\n" +
                $"Model: {car.Model.ToUpper()}\n" +
                $"Year: {car.Year}\n" +
                $"Fuel Type: {car.TypeOfFuel}\n" +
                $"_______________________"); 
            }
            else
            {
                Console.WriteLine("There was no car by that model");
            }
        }

        private void ViewCarByFuelType()
        {
            Console.Clear();

            Console.WriteLine("Please enter list of cars you would like to view: Electric, Hybrid, or Gas");

            string fuelType = Console.ReadLine().ToLower();

            Cars.FuelType car;

            if (fuelType != null)
            {
                if (fuelType == "electric")
                {
                    car = Cars.FuelType.Electric;

                    List<Cars> listOfCarType = _carRepo.ViewCarByFuelType(car);

                    foreach (Cars carType in listOfCarType)
                    {
                        Console.WriteLine($"Make: {carType.Make.ToUpper()}\n" +
                            $"Model: {carType.Model.ToUpper()}\n" +
                            $"Year: {carType.Year}\n" +
                            $"Fuel Type: {carType.TypeOfFuel}\n" +
                            $"_______________________");
                    }
                }
                else if (fuelType == "hybrid")
                {
                    car = Cars.FuelType.Hybrid;

                    List<Cars> listOfCarType = _carRepo.ViewCarByFuelType(car);

                    foreach (Cars carType in listOfCarType)
                    {
                        Console.WriteLine($"Make: {carType.Make.ToUpper()}\n" +
                            $"Model: {carType.Model.ToUpper()}\n" +
                            $"Year: {carType.Year}\n" +
                            $"Fuel Type: {carType.TypeOfFuel}\n" +
                            $"_______________________");
                    }
                }
                else if (fuelType == "gas")
                {
                    car = Cars.FuelType.Gas;

                    List<Cars> listOfCarType = _carRepo.ViewCarByFuelType(car);

                    foreach (Cars carType in listOfCarType)
                    {
                        Console.WriteLine($"Make: {carType.Make.ToUpper()}\n" +
                            $"Model: {carType.Model.ToUpper()}\n" +
                            $"Year: {carType.Year}\n" +
                            $"Fuel Type: {carType.TypeOfFuel}\n" +
                            $"_______________________");
                    }
                }
                else
                {
                    Console.WriteLine("We couldn't a find a list by that name. Please try again.");
                }
            }
        }
        //Update Cars
        private void UpdateCar()
        {
            Console.Clear();

            ViewAllCars();

            Console.WriteLine("Please enter the model of the car you'd like to update:");
            string originalModel = Console.ReadLine();

            Cars newCar = new Cars();

            Console.WriteLine("Please enter the updated make of the car:");
            newCar.Make = Console.ReadLine().ToLower();

            Console.WriteLine("Please enter the updated model of the car:");
            newCar.Model = Console.ReadLine().ToLower();

            Console.WriteLine("Please enter the updated year of the car:");
            string input = Console.ReadLine();
            int number;
            bool isNumber = Int32.TryParse(input, out number);
            if (isNumber == true)
            {
                newCar.Year = number;
            }
            else
            {
                Console.WriteLine("Please input a valid number\n" +
                       "Press any key to continue");
                Console.ReadKey();
                CreateCar();
            }

            Console.WriteLine("Please specify the updated fuel type of the vehicl(electric, hybrid, or gas):");
            string fuelInput = Console.ReadLine().ToLower();
            if (fuelInput == "electric")
            {
                newCar.TypeOfFuel = Cars.FuelType.Electric;
            }
            else if (fuelInput == "hybrid")
            {
                newCar.TypeOfFuel = Cars.FuelType.Hybrid;

            }
            else if (fuelInput == "gas")
            {
                newCar.TypeOfFuel = Cars.FuelType.Gas;

            }

            bool wasUpdated = _carRepo.UpdateCar(originalModel, newCar);

            if(wasUpdated == true)
            {
                Console.WriteLine("The car was successfully updated.");
            }
            else
            {
                Console.WriteLine("I'm sorry, the update was unsuccessful.");

            }

        }
        //Delete Cars
        private void DeleteCar()
        {
            bool inRemoval = true;

            while (inRemoval)
            {
                Console.Clear();

                Console.WriteLine("Please choose an option:\n" +
                    "1. Remove a car from a list.\n" +
                    "2. Remove a car from the system.\n" +
                    "3. Go back to the main menu" +
                    "\n");

            string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                        //Remove car from list
                        RemoveCarFromList();
                        break;
                    case "2":
                        //remove car from system
                        RemoveCarFromSystem();
                        break;
                    case "3":
                        //Exit
                        inRemoval = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }

                void RemoveCarFromList()
                {
                    Console.Clear();

                    Console.WriteLine("Please enter the list you wish to edit: electric, hybrid, or gas");
                    string fuelType = Console.ReadLine().ToLower();

                    Cars.FuelType car;

                    if (fuelType != null)
                    {
                        if (fuelType == "electric")
                        {
                            car = Cars.FuelType.Electric;

                            List<Cars> listOfCarType = _carRepo.ViewCarByFuelType(car);

                            foreach (Cars carType in listOfCarType)
                            {
                                Console.WriteLine($"Make: {carType.Make.ToUpper()}\n" +
                                    $"Model: {carType.Model.ToUpper()}\n" +
                                    $"Year: {carType.Year}\n" +
                                    $"Fuel Type: {carType.TypeOfFuel}\n" +
                                    $"_______________________");
                            }
                            Console.WriteLine("Please enter the model of the car you wish to remove:");
                            string model = Console.ReadLine();

                            Console.WriteLine($"Are you sure you want to remove this from the electric car list?\n" +
                                $"Y or N");
                            string confirm = Console.ReadLine().ToLower();
                            if (confirm == "y")
                            {
                                bool wasRemoved = _carRepo.RemoveCarFromTypeList(model, Cars.FuelType.Electric);
                               
                                if (wasRemoved == true)
                                {
                                    Console.WriteLine("The car was successfully removed from the system\n" +
                                                                        "Press any key to continue");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("I'm sorry, the removal was unsuccessful.");

                                }
                            }
                        }
                        else if (fuelType == "hybrid")
                        {
                            car = Cars.FuelType.Hybrid;

                            List<Cars> listOfCarType = _carRepo.ViewCarByFuelType(car);

                            foreach (Cars carType in listOfCarType)
                            {
                                Console.WriteLine($"Make: {carType.Make.ToUpper()}\n" +
                                    $"Model: {carType.Model.ToUpper()}\n" +
                                    $"Year: {carType.Year}\n" +
                                    $"Fuel Type: {carType.TypeOfFuel}\n" +
                                    $"_______________________");
                            }
                            Console.WriteLine("Please enter the model of the car you wish to remove:");
                            string model = Console.ReadLine();

                            Console.WriteLine($"Are you sure you want to remove this from the hybrid car list?\n" +
                                $"Y or N");
                            string confirm = Console.ReadLine().ToLower();
                            if (confirm == "y")
                            {
                                bool wasRemoved = _carRepo.RemoveCarFromTypeList(model, Cars.FuelType.Hybrid);

                                if (wasRemoved == true)
                                {
                                    Console.WriteLine("The car was successfully removed from the system\n" +
                                                                        "Press any key to continue");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("I'm sorry, the removal was unsuccessful.");

                                }
                            }
                        }
                        else if (fuelType == "gas")
                        {
                            car = Cars.FuelType.Gas;

                            List<Cars> listOfCarType = _carRepo.ViewCarByFuelType(car);

                            foreach (Cars carType in listOfCarType)
                            {
                                Console.WriteLine($"Make: {carType.Make.ToUpper()}\n" +
                                    $"Model: {carType.Model.ToUpper()}\n" +
                                    $"Year: {carType.Year}\n" +
                                    $"Fuel Type: {carType.TypeOfFuel}\n" +
                                    $"_______________________");
                            }
                            Console.WriteLine("Please enter the model of the car you wish to remove:");
                            string model = Console.ReadLine();

                            Console.WriteLine($"Are you sure you want to remove this from the gas car list?\n" +
                                $"Y or N");
                            string confirm = Console.ReadLine().ToLower();
                            if (confirm == "y")
                            {
                                bool wasRemoved = _carRepo.RemoveCarFromTypeList(model, Cars.FuelType.Gas);

                                if (wasRemoved == true)
                                {
                                    Console.WriteLine("The car was successfully removed from the list\n" +
                                                                        "Press any key to continue");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("I'm sorry, the removal was unsuccessful.");

                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("We couldn't a find a list by that name. Please try again.");
                        }
                    }
                }

                void RemoveCarFromSystem()
                {
                    Console.Clear();

                    ViewAllCars();

                    Console.WriteLine("Please enter the model of the car you wish to remove:");
                    string model = Console.ReadLine().ToLower();

                    Cars car = _carRepo.GetCarByModel(model);

                    if (car != null)
                    {
                        Console.WriteLine($"Make: {car.Make.ToUpper()}\n" +
                        $"Model: {car.Model.ToUpper()}\n" +
                        $"Year: {car.Year}\n" +
                        $"Fuel Type: {car.TypeOfFuel}\n" +
                        $"_______________________");

                        Console.WriteLine($"Are you sure you want to remove this car from the system?\n" +
                               $"Y or N");
                        string confirm = Console.ReadLine().ToLower();
                        if (confirm == "y")
                        {
                            bool wasRemoved = _carRepo.RemoveCarFromSystem(model);

                            if (wasRemoved == true)
                            {
                                Console.WriteLine("The car was successfully removed from the system\n" +
                                    "Press any key to continue");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("I'm sorry, the removal was unsuccessful.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There was no car by that model");
                        }

                    }
                }

            }

        }
    }
}
