using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resep_langkah.Data;
using resep_langkah.Models;
using Microsoft.EntityFrameworkCore;

namespace resep_langkah.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResepController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ResepController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(
            await _context.Resep.Include(r => r.Langkahs).ThenInclude(l => l.SubLangkahs).Include(r => r.Langkahs).ThenInclude(l => l.Parameters).ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var resep = await _context.Resep.Include(r => r.Langkahs).ThenInclude(l => l.Parameters).FirstOrDefaultAsync(r => r.Id == id);
            return resep == null ? NotFound() : Ok(resep);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Resep resep)
        {
            _context.Resep.Add(resep);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = resep.Id }, resep);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Resep updatedResep)
        {
            var resep = await _context.Resep.FindAsync(id);
            if (resep == null) return NotFound();

            resep.Nama = updatedResep.Nama;
            resep.Deskripsi = updatedResep.Deskripsi;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resep = await _context.Resep.FindAsync(id);
            if (resep == null) return NotFound();

            _context.Resep.Remove(resep);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
