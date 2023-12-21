using Api_TEST.DTOs.BrandDtos;
using Api_TEST.DTOs.CarDtos;
using Api_TEST.Entities;

namespace Api_TEST.Services.Interfaces
{
    public interface ICarService
    {
        Task<IQueryable<Car>> GetAll();
        Task<Car> GetById(int id);
        Task Create(CreateCarDto createCarDto);
        Task Delete(int id);
        Task Update(UpdateCarDto updateCarDto);
    }
}
