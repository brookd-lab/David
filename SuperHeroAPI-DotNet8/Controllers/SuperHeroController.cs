using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repo.Models;
using Repo.Services;

namespace SuperHeroAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly SuperHeroService _repo;

        public SuperHeroController(SuperHeroService repo)
        {
            _repo = repo;
        }

        [HttpGet("/SuperHero/GetAll")]
        public async Task<IResult> GetAllHeroes()
        {
            return await _repo.GetAllHeroes();
        }

        [HttpPost("SuperHero/Add")]
        public async Task<IResult> AddHero(SuperHero hero)
        {
            return await _repo.AddHero(hero);
        }

        [HttpPut("SuperHero/Update")]
        public async Task<IResult> UpdateHero(SuperHero hero)
        {
            return await _repo.UpdateHero(hero);
        }

        [HttpDelete("SuperHero/Delete/{id}")]
        public async Task<IResult> DeleteHero(int id)
        {
            return await _repo.DeleteHero(id);
        }

        [HttpGet("/SuperHero/GetById/{id}")]
        public async Task<IResult> GetHeroById(int id)
        {
            return await _repo.GetHeroById(id);
        }
    }
}
