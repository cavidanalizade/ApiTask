namespace Api_TEST.DTOs.CarDtos
{
    public class UpdateCarDto
    {
        public int Id { get; set; }
        public int? BrandId { get; set; }
        public int? ModelYear { get; set; }
        public double? DailyPrice { get; set; }
        public string? Description { get; set; }
    }
}
