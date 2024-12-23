using LevshinaRecipes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApiProject.Data;

namespace LevshinaRecipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Внедряем DbContext через конструктор
        public DishesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDishes()
        {
            var dishes = await _context.Dishes.ToListAsync();
            return Ok(dishes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDishById(int id)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(d => d.Id == id);
            return dish != null ? Ok(dish) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddDish([FromBody] Dish dish)
        {
            if (dish.CookingTime <= 0)
                return BadRequest("Время приготовления не может быть меньше 0.");

            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDishById), new { id = dish.Id }, dish);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish(int id)
        {
            var dish = await _context.Dishes.FirstOrDefaultAsync(d => d.Id == id);
            if (dish == null) return NotFound();

            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("by-category/{categoryId}")]
        public async Task<IActionResult> GetDishesByCategory(int categoryId)
        {
            var filteredDishes = await _context.Dishes
                .Where(d => d.CategoryId == categoryId)
                .ToListAsync();

            return Ok(filteredDishes);
        }
    }
}