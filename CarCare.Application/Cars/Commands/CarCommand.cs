using CarCare.Application.Common.Interfaces.Persistence;
using CarCare.Domain.Entities;
using MediatR;

namespace CarCare.Application.Cars.Commands
{
    public class CreateCarCommand : IRequest
    {
        public string RegistrationNumber { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string ModelYear { get; set; } = null!;
    }

    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly ICarRepository _carRepository;
        public CreateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = new Car
            {
                RegistrationNumber = request.RegistrationNumber,
                Model = request.Model,
                ModelYear = request.ModelYear
            };

            await Task.Run(() => _carRepository.AddCar(car));

        }
    }
}
