using CarCare.Application.Common.Interfaces.Persistence;
using MediatR;

namespace CarCare.Application.Cars.Queries
{
    public class GetCarsQuery : IRequest<List<GetCarsQueryResponse>>
    {
    }

    public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, List<GetCarsQueryResponse>>
    {
        private readonly ICarRepository _carRepository;
        public GetCarsQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<List<GetCarsQueryResponse>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = _carRepository.GetCars();
            return cars.Select(car => new GetCarsQueryResponse
            {
                Id = car.Id,
                RegistrationNumber = car.RegistrationNumber,
                Model = car.Model,
                ModelYear = car.ModelYear
            }).ToList();
        }
    }

    public class GetCarsQueryResponse
    {
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; } = default!;
        public string Model { get; set; } = default!;
        public string ModelYear { get; set; } = default!;
    }
}
