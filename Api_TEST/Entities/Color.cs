namespace Api_TEST.Entities
{
    public class Color:BaseEntity
    {
        public string? Name { get; set; }
        public List<Car> cars { get; set; }

    }
}
