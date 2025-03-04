using CarCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCare.Application.Common.Interfaces.Persistence
{
    public interface ICarRepository
    {
        public List<Car> GetCars();
        void AddCar(Car car);
        Car? GetCarByRegistrationNumber(string registrationNumber);
    }
}
