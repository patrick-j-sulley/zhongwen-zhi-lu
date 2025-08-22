using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zhongwen_zhi_lu.Data;

[ApiController]
[Route("api/[controller]")]
public class WeekController : ControllerBase
{
    private readonly AppDbContext _db;
    public WeekController(AppDbContext db) => _db = db;

    [HttpGet("with-phrases")]
    public async Task<IActionResult> GetWeeksWithPhrases()
    {
        var weeks = await _db.Weeks
            .Select(week => new {
                week.Id,
                week.StartDate,
                week.EndDate,
                Phrases = _db.Phrases
                    .Where(p => p.WeekId == week.Id)
                    .Select(p => new {
                        p.Id,
                        p.Chinese,
                        p.Pinyin,
                        p.English,
                        Category = _db.Categories
                            .Where(c => c.Id == p.CategoryId)
                            .Select(c => new { c.Id, c.Name, c.Description })
                            .FirstOrDefault()
                    }).ToList()
            }).ToListAsync();

        return Ok(weeks);
    }
}
