using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  

namespace zhongwen_zhi_lu.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhraseController : ControllerBase
    {
        private readonly Data.AppDbContext _context;

        public PhraseController(Data.AppDbContext context)
        {
            _context = context;
        }

        //Get: api/phrase
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phrase>>> GetPhrases()
        {
            // Fetch all phrases from the database
            var phrases = await _context.Phrases.ToListAsync();

            return Ok(phrases);
        }
    }
}