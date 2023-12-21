using Api_TEST.DAL;
using Api_TEST.DTOs.BrandDtos;
using Api_TEST.DTOs.CarDtos;
using Api_TEST.Entities;
using Api_TEST.Repositories.Interfaces;
using Api_TEST.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IBrandRepository _repository;
        private readonly IBrandService _brandService;

        public BrandController(AppDbContext context, IBrandRepository repository, IBrandService brandService )
        {
            _context = context;
            _repository = repository;
            _brandService = brandService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = _brandService.GetAll();

            return StatusCode(StatusCodes.Status200OK, brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           
            Brand brand = await _brandService.GetById(id);
           
            return StatusCode(statusCode: 200, brand);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateBrandDto createBrandDto)
        {
            
            await _brandService.Create(createBrandDto);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] UpdateBrandDto updateBrandDto)
        {       
            await _brandService.Update(updateBrandDto);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
          

            await _brandService.Delete(id);
            _repository.Save();


            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
