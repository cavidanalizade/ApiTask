using Api_TEST.DAL;
using Api_TEST.DTOs.BrandDtos;
using Api_TEST.DTOs.CarDtos;
using Api_TEST.Entities;
using Api_TEST.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ICarRepository _repository;


        public CarController(AppDbContext context , ICarRepository repository)
        {
            _context = context;
            _repository = repository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cars = await _repository.GetAll();

            return StatusCode(StatusCodes.Status200OK, cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            Car car = await _repository.GetById(id);
            if (car == null)
            {
                return NotFound();
            }
            return StatusCode(statusCode: 200, car);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateCarDto createCarDto)
        {
            if (createCarDto == null)
            {
                return BadRequest("Invalid brand data");
            }
            Car car = new Car()
            {
                Description = createCarDto.Description,
                BrandId=createCarDto.BrandId,
                ModelYear=createCarDto.ModelYear,
                DailyPrice=createCarDto.DailyPrice
            };
            _repository.Create(car);
            _repository.Save();

            return StatusCode(StatusCodes.Status201Created, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] UpdateCarDto updateCarDto)
        {
            if (updateCarDto == null)
            {
                return BadRequest("Invalid data");
            }

            var existingCar = await _repository.GetById(updateCarDto.Id);

            if (existingCar == null)
            {
                return NotFound();
            }

            existingCar.Description = updateCarDto.Description;
            existingCar.BrandId = updateCarDto.BrandId;
            existingCar.ModelYear = updateCarDto.ModelYear;
            existingCar.DailyPrice = updateCarDto.DailyPrice;
            _repository.Update(existingCar);

            _repository.Save();

            return StatusCode(StatusCodes.Status200OK, existingCar);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            _repository.delete(id);
            _repository.Save();


            return Ok();
        }

    }
}
