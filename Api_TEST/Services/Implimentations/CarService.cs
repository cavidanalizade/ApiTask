using Api_TEST.DTOs.BrandDtos;
using Api_TEST.DTOs.CarDtos;
using Api_TEST.Entities;
using Api_TEST.Repositories.Interfaces;

namespace Api_TEST.Services.Implimentations
{
    public class CarService
    {
        private readonly ICarRepository _repository;

        public CarService(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task Create(CreateCarDto createCarDto)
        {
            if (createCarDto == null)
            {
                throw new Exception("No content");

            }
            Car car = new Car()
            {
                Description = createCarDto.Description,
                BrandId=createCarDto.BrandId,
                ModelYear=createCarDto.ModelYear,
                DailyPrice=createCarDto.DailyPrice
            };
            await _repository.Create(car);
            _repository.Save();
        }

        public void Delete(int id)
        {
            if (id <= 0) throw new Exception("Bad request");
            _repository.delete(id);
            _repository.Save();
        }

        public async Task<IQueryable<Car>> GetAll()
        {
            return await _repository.GetAll();
        }

        public Task<Car> GetById(int id)
        {
            if (id <= 0) throw new Exception("Bad request");

            var car = _repository.GetById(id);
            if (car == null) throw new Exception("No content");
            return car;


        }

        public async Task Update(UpdateCarDto updateCarDto)
        {
            if (updateCarDto == null) throw new Exception("Bad request");
            var existingBrand = await _repository.GetById(updateCarDto.Id);
            existingBrand.Description = updateCarDto.Description;
            existingBrand.BrandId = updateCarDto.BrandId;
            existingBrand.ModelYear = updateCarDto.ModelYear;
            existingBrand.DailyPrice = updateCarDto.DailyPrice;
            _repository.Update(existingBrand);
            _repository.Save();
        }
    }
}
