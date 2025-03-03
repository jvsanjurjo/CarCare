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
        Car? GetCarByRegistrationNumber(string registrationNumber);
        void AddCar(Car car);
    }
}
