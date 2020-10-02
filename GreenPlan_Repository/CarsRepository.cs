using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlan_Repository
{
    public class CarsRepository
    {
        public List<Cars> ListOfCars = new List<Cars>();
        public List<Cars> ElectricCars = new List<Cars>();
        public List<Cars> HybridCars = new List<Cars>();
        public List<Cars> GasCars = new List<Cars>();
        

        //Create
        public void CreateCar(Cars car, Cars.FuelType typeOfFuel)
        {
            ListOfCars.Add(car);

            if(typeOfFuel == Cars.FuelType.Electric)
            {
                ElectricCars.Add(car);
            }
            else if (typeOfFuel == Cars.FuelType.Hybrid)
            {
                HybridCars.Add(car);
            }
            else if (typeOfFuel == Cars.FuelType.Gas)
            {
                GasCars.Add(car);
            }
        }

        //Read
        public List<Cars> ViewAllCars()
        {
            return ListOfCars;
        }

        public List<Cars> ViewCarByFuelType(Cars.FuelType typeOfFuel)
        {
            if (typeOfFuel == Cars.FuelType.Electric)
            {
                return ElectricCars;
            }
            else if(typeOfFuel == Cars.FuelType.Hybrid)
            {
                return HybridCars;
            }
            else if (typeOfFuel == Cars.FuelType.Gas)
            {
                return GasCars;
            }
            else
            {
                Console.WriteLine("We could not find the car in the Electric, Hybrid, or Gas lists.\n" +
                    "Please try again");
                return ListOfCars;
            }
        }


        //Update
        public bool UpdateCar(string originalCar, Cars newCar)
        {
            //Find the car
            Cars oldCar = GetCarByModel(originalCar);

            //Update the car

            if (oldCar != null)
            {
                oldCar.Make = newCar.Make;
                oldCar.Model = newCar.Model;
                oldCar.Year = newCar.Year;
                oldCar.TypeOfFuel = newCar.TypeOfFuel;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveCarFromSystem(string model)
        {
            Cars car = GetCarByModel(model);

            if (car == null)
            {
                return false;
            }

            int initialCount = ListOfCars.Count;
            ListOfCars.Remove(car);

            if (initialCount > ListOfCars.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveCarFromTypeList(string model, Cars.FuelType typeOfFuel)
        {
            Cars car = GetCarByModel(model);


            if (car == null)
            {
                return false;
            }
            else if (typeOfFuel == Cars.FuelType.Electric)
            {
                int initialCount = ElectricCars.Count;
                ElectricCars.Remove(car);

                if (initialCount > ElectricCars.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (typeOfFuel == Cars.FuelType.Hybrid)
            {
                int initialCount = HybridCars.Count;
                HybridCars.Remove(car);

                if (initialCount > HybridCars.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (typeOfFuel == Cars.FuelType.Hybrid)
            {
                int initialCount = GasCars.Count;
                GasCars.Remove(car);

                if (initialCount > GasCars.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("We could not find the car in the Electric, Hybrid, or Gas lists.\n" +
                    "Please try again");
                return false;
            }
        }

        //Helper Methods

        public Cars GetCarByModel(string model)
        {
            foreach(Cars car in ListOfCars)
            {
                if(car.Model.ToLower() == model.ToLower())
                {
                    return car;
                }
                
            }
            return null;
        }
    }
}
