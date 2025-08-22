using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace zhongwen_zhi_lu.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly Data.AppDbContext _context;

        public CategoryController(Data.AppDbContext context)
        {
            _context = context;
        }

        // Get: api/category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            // Fetch all categories from the database
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }
    }
}