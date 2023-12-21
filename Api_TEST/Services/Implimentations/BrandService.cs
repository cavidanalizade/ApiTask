using Api_TEST.DTOs.BrandDtos;
using Api_TEST.Entities;
using Api_TEST.Repositories.Interfaces;
using Api_TEST.Services.Interfaces;

namespace Api_TEST.Services.Implimentations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;

        public BrandService(IBrandRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateBrandDto createBrandDto)
        {
            if (createBrandDto == null)
            {
                throw new Exception("No content");

            }
            Brand brand = new Brand()
            {
                Name = createBrandDto.Name
            };
            await _repository.Create(brand);
             _repository.Save();
        }

        public async Task Delete(int id)
        {
            if (id <= 0) throw new Exception("Bad request");

            _repository.delete(id);
            _repository.Save();
        }

        public async Task<IQueryable<Brand>> GetAll()
        {
            return await _repository.GetAll();
        }

        public Task<Brand> GetById(int id)
        {
            if (id <= 0) throw new Exception("Bad request");

            var brand=_repository.GetById(id);
            
            if (brand == null) throw new Exception("No content");
            return brand;


        }

        public async Task Update(UpdateBrandDto updateBrandDto)
        {
            if (updateBrandDto == null) throw new Exception("Bad request");
            var existingBrand = await _repository.GetById(updateBrandDto.Id);
            existingBrand.Name=updateBrandDto.Name;
            _repository.Update(existingBrand);
            _repository.Save();
        }
    }
}
