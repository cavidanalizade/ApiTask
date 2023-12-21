using Api_TEST.DTOs.BrandDtos;
using Api_TEST.Entities;

namespace Api_TEST.Services.Interfaces
{
    public interface IBrandService
    {
        Task<IQueryable<Brand>> GetAll();
        Task<Brand> GetById(int id);
        Task Create(CreateBrandDto createBrandDto);
        Task Delete(int id);
        Task Update(UpdateBrandDto updateBrandDto);
    }
}
