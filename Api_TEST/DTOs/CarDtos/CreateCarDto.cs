namespace Api_TEST.DTOs.CarDtos
{
    public class CreateCarDto
    {
        public int? BrandId { get; set; }
        public int? ModelYear { get; set; }
        public double? DailyPrice { get; set; }
        public string? Description { get; set; }
    }
}
