using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repo.Data;
using Repo.Models;

namespace Repo.Services
{
    public class SuperHeroService
    {
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<IResult> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            if (heroes == null)
            {
                return Results.NotFound("There are no heroes yet!");
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
                return Results.NotFound($"Hero not found for id: {id}");
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
            return Results.Created("SuperHero/Add", await _context.SuperHeroes.ToListAsync());
        }

        public async Task<IResult> UpdateHero(SuperHero hero)
        {
            var foundHero = await _context.SuperHeroes.FindAsync(hero.Id);
            if (foundHero == null)
            {
                return Results.NotFound($"Could not find hero by id: {hero.Id}");
            }
            else
            {
                _context.Update<SuperHero>(hero);
                await _context.SaveChangesAsync();
                return Results.Ok(await _context.SuperHeroes.ToListAsync());
            }
        }

        public async Task<IResult> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return Results.NotFound("No hero to delete");
            }
            else
            {
                _context.SuperHeroes.Remove(hero);
                await _context.SaveChangesAsync();
                return Results.Ok(await _context.SuperHeroes.ToListAsync());
            }
        }
    }
}
