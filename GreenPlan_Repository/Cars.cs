using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlan_Repository
{
    public class Cars
    {
        public enum FuelType
        {
            Gas = 1,
            Hybrid,
            Electric
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public FuelType TypeOfFuel { get; set; }

        public Cars() { }

        public Cars(string make, string model, int year, FuelType typeOfFuel)
        {
            Make = make;
            Model = model;
            Year = year;
            TypeOfFuel = typeOfFuel;

        }

    }
}
