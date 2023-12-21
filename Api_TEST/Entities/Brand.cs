namespace Api_TEST.Entities
{
    public class Brand:BaseEntity
    {
        public string? Name { get; set; }
        public List<Car>? cars { get; set; }

    }
}
