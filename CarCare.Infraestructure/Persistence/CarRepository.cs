using CarCare.Application.Common.Interfaces.Persistence;
using CarCare.Domain.Entities;

namespace CarCare.Infraestructure.Persistence
{
    public class CarRepository:ICarRepository
    {
        private static readonly List<Car> _cars = new List<Car>();

        public void AddCar(Car car)
        {
            _cars.Add(car);
        }

        public Car? GetCarByRegistrationNumber(string registrationNumber)
        {
            return _cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }
    }
}
