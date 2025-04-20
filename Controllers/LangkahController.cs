using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resep_langkah.Data;
using resep_langkah.Models;
using Microsoft.EntityFrameworkCore;

namespace resep_langkah.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LangkahController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LangkahController(AppDbContext context) => _context = context;

        [HttpGet("ByResep/{resepId}")]
        public async Task<IActionResult> GetLangkahByResep(int resepId)
        {
            var langkah = await _context.Langkah
                .Where(l => l.ResepId == resepId && l.ParentLangkahId == null)
                .Include(l => l.SubLangkahs).Include(l => l.Parameters).ToListAsync();
            return Ok(langkah);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var langkah = await _context.Langkah.Include(l => l.SubLangkahs).Include(l => l.Parameters).FirstOrDefaultAsync(l => l.Id == id);
            return langkah == null ? NotFound() : Ok(langkah);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Langkah langkah)
        {
            _context.Langkah.Add(langkah);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = langkah.Id }, langkah);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Langkah updated)
        {
            var langkah = await _context.Langkah.FindAsync(id);
            if (langkah == null) return NotFound();

            langkah.Judul = updated.Judul;
            langkah.Urutan = updated.Urutan;
            langkah.ParentLangkahId = updated.ParentLangkahId;
            langkah.ResepId = updated.ResepId;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var langkah = await _context.Langkah.FindAsync(id);
            if (langkah == null) return NotFound();

            _context.Langkah.Remove(langkah);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
