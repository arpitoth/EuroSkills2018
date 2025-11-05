using EuroSkillsApi.Data;
using Microsoft.AspNetCore.Mvc;
using EuroSkillsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EuroSkillsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VersenyzoController : ControllerBase
{
    private readonly VersenyDbContext _context;
    public VersenyzoController(VersenyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Versenyzo>>> GetVersenyzo()
    {
        return await _context.Versenyzok.ToListAsync();
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Versenyzo>> GetVersenyzoId(string id)
    {
        var versenyzo = await _context.Versenyzok.FindAsync(id);

        if (versenyzo == null)
        {
            return NotFound();
        }

        return versenyzo;
    }

    [HttpPost]
    public async Task<ActionResult<Versenyzo>> PostVersenyzo(Versenyzo versenyzo)
    {
        _context.Versenyzok.Add(versenyzo);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch("{Id}")]
    public async Task<ActionResult<Versenyzo>> UpdateVersenyzo(int id, Versenyzo updatedData)
    {
        var versenyzo = await _context.Versenyzok.FirstOrDefaultAsync(x => x.Id == id);
        if (versenyzo == null)
        {
            return NotFound();
        }
        if (updatedData.Nev == null) versenyzo.Nev = updatedData.Nev;
        if (updatedData.SzakmaId == null) versenyzo.SzakmaId = updatedData.SzakmaId;
        if (updatedData.OrszagId == null) versenyzo.OrszagId = updatedData.OrszagId;
        if (updatedData.Pont == null) versenyzo.Pont = updatedData.Pont;
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{Id}")] 
    public async Task<ActionResult<Versenyzo>> DeleteVersenyzo(string id)
    {
        var versenyzo = await _context.Versenyzok.FindAsync(id);
        if (versenyzo == null)
        {
            return NotFound();
        }
        _context.Versenyzok.Remove(versenyzo);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
