using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Data;
using SuperHeroAPI_DotNet8.Entities;

namespace SuperHeroAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("/SuperHero/GetAll")]
        public async Task<IActionResult> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            if (heroes == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(heroes);
            }
        }

        [HttpPost("SuperHero/Add")]
        public async Task<IActionResult> AddHero(SuperHero hero)
        {
            await _context.AddAsync(hero);
            await _context.SaveChangesAsync();
            return Created("SuperHero/Add", hero);
        }

        [HttpPut("SuperHero/Update")]
        public async Task<IActionResult> UpdateHero(SuperHero hero)
        {
            _context.Update<SuperHero>(hero);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("SuperHero/Delete/{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero = await FindHero(id);
            if (hero ==  null)
            {
                return NotFound(hero);
            }
            else
            {
                _context.SuperHeroes.Remove(hero);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }

        private async Task<SuperHero> FindHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            return hero;
        }


        [HttpGet("/SuperHero/GetById/{id}")]
        public async Task<IActionResult> GetHeroById(int id)
        {
            var hero = await FindHero(id);
            if (hero == null)
            {
                return NotFound(hero);
            }
            else
            {
                return Ok(hero);
            }
        }
    }
}
