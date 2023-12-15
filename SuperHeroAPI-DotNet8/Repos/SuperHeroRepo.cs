using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Data;
using SuperHeroAPI_DotNet8.Entities;

namespace SuperHeroAPI_DotNet8.Repos
{
    public class SuperHeroRepo
    {
        private readonly DataContext _context;

        public SuperHeroRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<IResult> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            if (heroes == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(heroes);
            }
        }


        [HttpGet("/SuperHero/GetById/{id}")]
        public async Task<IResult> GetHeroById(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return Results.NotFound(hero);
            }
            else
            {
                return Results.Ok(hero);
            }
        }

        public async Task<IResult> AddHero(SuperHero hero)
        {
            await _context.AddAsync(hero);
            await _context.SaveChangesAsync();
            return Results.Created("SuperHero/Add", hero);
        }

        public async Task<IResult> UpdateHero(SuperHero hero)
        {
            _context.Update<SuperHero>(hero);
            await _context.SaveChangesAsync();
            return Results.NoContent();
        }

        public async Task<IResult> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return Results.NotFound();
            }
            else
            {   
                _context.SuperHeroes.Remove(hero);
                await _context.SaveChangesAsync();
                return Results.NoContent();
            }
        }
    }
}
