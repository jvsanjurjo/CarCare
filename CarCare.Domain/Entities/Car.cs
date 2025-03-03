namespace CarCare.Domain.Entities
{
    public class Car
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Model { get; set; } = null!;
        public string ModelYear { get; set; } = null!;
    }
}
