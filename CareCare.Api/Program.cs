using CarCare.Application;
using CarCare.Application.Common.Interfaces.Persistence;
using CarCare.Domain.Entities;
using CarCare.Infraestructure;
using CareCare.Api;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfraestructure(builder.Configuration);
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    await SeedCars();

    app.Run();
}

async Task SeedCars()
{
    using (var scope = app.Services.CreateScope())
    {
        var carRepository = scope.ServiceProvider.GetRequiredService<ICarRepository>();
        var cars = new List<Car>
        {
            new Car
            {
                Id = Guid.NewGuid(),
                RegistrationNumber = "ABC123",
                Model = "Toyota",
                ModelYear = "2020"
            },
            new Car
            {
                Id = Guid.NewGuid(),
                RegistrationNumber = "DEF456",
                Model = "Honda",
                ModelYear = "2019"
            }
        };
        foreach (var car in cars)
        {
            carRepository.AddCar(car);
        }
    }
}