using GuramHM.DB.Models;
using GuramHM.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuramHM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SampleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SampleModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleModel>>> GetSampleModels()
        {
            return await _context.SampleModels.ToListAsync();
        }

        // GET: api/SampleModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleModel>> GetSampleModel(int id)
        {
            var sampleModel = await _context.SampleModels.FindAsync(id);

            if (sampleModel == null)
            {
                return NotFound();
            }

            return sampleModel;
        }

        // PUT: api/SampleModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleModel(int id, SampleModel sampleModel)
        {
            if (id != sampleModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(sampleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SampleModels
        [HttpPost]
        public async Task<ActionResult<SampleModel>> PostSampleModel(SampleModel sampleModel)
        {
            _context.SampleModels.Add(sampleModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampleModel", new { id = sampleModel.Id }, sampleModel);
        }

        // DELETE: api/SampleModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSampleModel(int id)
        {
            var sampleModel = await _context.SampleModels.FindAsync(id);
            if (sampleModel == null)
            {
                return NotFound();
            }

            _context.SampleModels.Remove(sampleModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SampleModelExists(int id)
        {
            return _context.SampleModels.Any(e => e.Id == id);
        }
    }
}
