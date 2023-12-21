/*using Api_TEST.DAL;
using Api_TEST.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_TEST.Controllers
{
    public class ColorController
    {
        private readonly AppDbContext _context;

        public ColorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Color> colors = await _context.colors.ToListAsync();
            if (colors.Count == 0)
            {
                return OkResult()
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Car car = await _context.cars.SingleOrDefaultAsync(b => b.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest("Invalid car data");
            }

            _context.cars.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Car updatedcar)
        {
            if (updatedcar == null || id != updatedcar.Id)
            {
                return BadRequest("Invalid data");
            }

            var existingcar = await _context.cars.FindAsync(id);

            if (existingcar == null)
            {
                return NotFound();
            }

            existingcar.Description = updatedcar.Description;
            existingcar.DailyPrice = updatedcar.DailyPrice;
            existingcar.BrandId = updatedcar.BrandId;
            existingcar.ColorId = updatedcar.ColorId;
            existingcar.ModelYear = updatedcar.ModelYear;


            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0 || (!_context.cars.Any(b => b.Id == id)))
            {
                return BadRequest();
            }
            var deleteCar = _context.cars.FirstOrDefault(b => b.Id == id);
            _context.cars.Remove(deleteCar);


            return Ok();
        }
    }
}
*/