using EuroSkillsApi.Data;
using Microsoft.AspNetCore.Mvc;
using EuroSkillsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EuroSkillsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SzakmaController : ControllerBase
{
    private readonly VersenyDbContext _context;
    public SzakmaController(VersenyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Szakma>>> GetSzakma()
    {
        return await _context.Szakmak.ToListAsync();
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Szakma>> GetSzakmaId(string id)
    {
        var szakma = await _context.Szakmak.FindAsync(id);

        if (szakma == null)
        {
            return NotFound();
        }

        return szakma;
    }

    [HttpPost]
    public async Task<ActionResult<Szakma>> PostSzakma(Szakma szakma)
    {
        _context.Szakmak.Add(szakma);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch("{Id}")]
    public async Task<ActionResult<Szakma>> UpdateSzakma(string id, Szakma updatedData)
    {
        var szakma = await _context.Szakmak.FirstOrDefaultAsync(x => x.Id == id);
        if (szakma == null)
        {
            return NotFound();
        }
        if (updatedData.SzakmaNev == null) szakma.SzakmaNev = updatedData.SzakmaNev;
        await _context.SaveChangesAsync();
        return Ok();

    }
    
    [HttpDelete("{Id}")] 
    public async Task<ActionResult<Szakma>> DeleteSzakma(string id)
    {
        var szakma = await _context.Szakmak.FindAsync(id);
        if (szakma == null)
        {
            return NotFound();
        }
        _context.Szakmak.Remove(szakma);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
