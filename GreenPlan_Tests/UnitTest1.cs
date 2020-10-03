using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreenPlan_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateCar()
        {
            GreenPlan_Repository.Cars newCar = new GreenPlan_Repository.Cars("Toyota", "Prius", 2019, GreenPlan_Repository.Cars.FuelType.Hybrid);

            GreenPlan_Repository.CarsRepository _newRepo = new GreenPlan_Repository.CarsRepository();

            _newRepo.CreateCar(newCar, newCar.TypeOfFuel);
        }

        [TestMethod]
        public void TestViewAllCars()
        {
            GreenPlan_Repository.Cars newCar = new GreenPlan_Repository.Cars("Toyota", "Prius", 2019, GreenPlan_Repository.Cars.FuelType.Hybrid);

            GreenPlan_Repository.CarsRepository _newRepo = new GreenPlan_Repository.CarsRepository();

            _newRepo.CreateCar(newCar, newCar.TypeOfFuel);

            _newRepo.ViewAllCars();
        }

        [TestMethod]
        public void TestViewCarsByFuelType()
        {
            GreenPlan_Repository.Cars newCar = new GreenPlan_Repository.Cars("Toyota", "Prius", 2019, GreenPlan_Repository.Cars.FuelType.Hybrid);

            GreenPlan_Repository.CarsRepository _newRepo = new GreenPlan_Repository.CarsRepository();

            _newRepo.CreateCar(newCar, newCar.TypeOfFuel);

            _newRepo.ViewCarByFuelType(newCar.TypeOfFuel);
        }


        [TestMethod]
        public void TestUpdateCar()
        {
            GreenPlan_Repository.Cars originalCar = new GreenPlan_Repository.Cars("Toyota", "Prius", 2019, GreenPlan_Repository.Cars.FuelType.Hybrid);
            GreenPlan_Repository.Cars newCar = new GreenPlan_Repository.Cars("Toyota", "Camry", 2018, GreenPlan_Repository.Cars.FuelType.Gas);

            GreenPlan_Repository.CarsRepository _newRepo = new GreenPlan_Repository.CarsRepository();

            _newRepo.CreateCar(originalCar, originalCar.TypeOfFuel);

            originalCar = newCar;

            _newRepo.UpdateCar(originalCar.Model, originalCar);
        }


        [TestMethod]
        public void TestRemoveCarFromSystem()
        {
            GreenPlan_Repository.Cars newCar = new GreenPlan_Repository.Cars("Toyota", "Prius", 2019, GreenPlan_Repository.Cars.FuelType.Hybrid);

            GreenPlan_Repository.CarsRepository _newRepo = new GreenPlan_Repository.CarsRepository();

            _newRepo.CreateCar(newCar, newCar.TypeOfFuel);

            _newRepo.RemoveCarFromSystem(newCar.Model);
        }

        [TestMethod]
        public void TestRemoveCarFromList()
        {
            GreenPlan_Repository.Cars newCar = new GreenPlan_Repository.Cars("Toyota", "Prius", 2019, GreenPlan_Repository.Cars.FuelType.Hybrid);

            GreenPlan_Repository.CarsRepository _newRepo = new GreenPlan_Repository.CarsRepository();

            _newRepo.CreateCar(newCar, newCar.TypeOfFuel);

            _newRepo.RemoveCarFromTypeList(newCar.Model, newCar.TypeOfFuel);
        }
    }
}
