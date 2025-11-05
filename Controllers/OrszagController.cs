using EuroSkillsApi.Data;
using Microsoft.AspNetCore.Mvc;
using EuroSkillsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EuroSkillsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrszagController : ControllerBase
{
    private readonly VersenyDbContext _context;
    public OrszagController(VersenyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Orszag>>> GetOrszag()
    {
        return await _context.Orszagok.ToListAsync();
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Orszag>> GetOrszagId(string id)
    {
        var orszag = await _context.Orszagok.FindAsync(id);

        if (orszag == null)
        {
            return NotFound();
        }

        return orszag;
    }

    [HttpPost]
    public async Task<ActionResult<Orszag>> PostOrszag(Orszag orszag)
    {
        _context.Orszagok.Add(orszag);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch("{Id}")]
    public async Task<ActionResult<Orszag>> UpdateOrszag(string id, Orszag updatedData)
    {
        var orszag = await _context.Orszagok.FirstOrDefaultAsync(x => x.Id == id);
        if (orszag == null)
        {
            return NotFound();
        }
        if (updatedData.OrszagNev == null) orszag.OrszagNev = updatedData.OrszagNev;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{Id}")] 
    public async Task<ActionResult<Orszag>> DeleteOrszag(string id)
    {
        var orszag = await _context.Orszagok.FindAsync(id);
        if (orszag == null)
        {
            return NotFound();
        }
        _context.Orszagok.Remove(orszag);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
