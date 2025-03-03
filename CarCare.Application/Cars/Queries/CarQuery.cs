using CarCare.Application.Common.Interfaces.Persistence;
using MediatR;

namespace CarCare.Application.Cars.Queries
{
    public class GetCarQuery:IRequest<GetCarQueryResponse>
    {
        public string RegistrationNumber { get; set; }
    }

    public class GetCarQueryHandler: IRequestHandler<GetCarQuery, GetCarQueryResponse>
    {
        private readonly ICarRepository _carRepository;
        public GetCarQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<GetCarQueryResponse> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var car = _carRepository.GetCarByRegistrationNumber(request.RegistrationNumber);
            return new GetCarQueryResponse
            {
                Id = car.Id,
                RegistrationNumber = car.RegistrationNumber,
                Model = car.Model,
                ModelYear = car.ModelYear
            };
        }
    }

    public class GetCarQueryResponse
    {
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; } = default!;
        public string Model { get; set; } = default!;
        public string ModelYear { get; set; } = default!;
    }
}
