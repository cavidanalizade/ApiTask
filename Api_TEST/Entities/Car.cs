namespace Api_TEST.Entities
{
    public class Car:BaseEntity
    {
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int? ColorId { get; set; }
        public Color? Color { get; set; }
        public int? ModelYear { get; set; }
        public double? DailyPrice { get; set; }
        public string? Description { get; set; }

    }
}
