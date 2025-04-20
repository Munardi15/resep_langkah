using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using resep_langkah.Data;
using resep_langkah.Models;
using Microsoft.EntityFrameworkCore;

namespace resep_langkah.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ParameterController(AppDbContext context) => _context = context;

        [HttpGet("ByLangkah/{langkahId}")]
        public async Task<IActionResult> GetByLangkah(int langkahId) => Ok(
            await _context.Parameter.Where(p => p.LangkahId == langkahId).ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var param = await _context.Parameter.FindAsync(id);
            return param == null ? NotFound() : Ok(param);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Parameter parameter)
        {
            _context.Parameter.Add(parameter);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = parameter.Id }, parameter);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Parameter updated)
        {
            var parameter = await _context.Parameter.FindAsync(id);
            if (parameter == null) return NotFound();

            parameter.Nama = updated.Nama;
            parameter.TipeData = updated.TipeData;
            parameter.Nilai = updated.Nilai;
            parameter.LangkahId = updated.LangkahId;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var parameter = await _context.Parameter.FindAsync(id);
            if (parameter == null) return NotFound();

            _context.Parameter.Remove(parameter);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
