using Microsoft.AspNetCore.Mvc;
using Test.Shared.Data;
using Test.Shared.Repo;

namespace Test.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperRepository _repo;
        private readonly ILogger<DeveloperController> _logger;

        public DeveloperController(IDeveloperRepository repo,
            ILogger<DeveloperController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        [HttpGet]
        public async Task<List<Developer>> GetAllDevelopers()
        {
            var developers = await _repo.GetAll();
            return developers;
        }
        [HttpGet("{id}")]
        public async Task<Developer?> GetDeveloperById(int id)
        {
            Developer? developer = await _repo.GetById(id);
            return developer;
        }
        [HttpPost]
        public async Task<Developer?> InsertDeveloper(Developer developer)
        {
            await _repo.Insert(developer);
            return developer;
        }
        [HttpPut]
        public async Task<Developer?> UpdateDeveloper(Developer developer)
        {
            await _repo.Update(developer);
            return developer;
        }
        [HttpDelete]
        public async Task<Developer?> RemoveDeveloper(int id)
        {
            Developer? developer = await _repo.GetById(id);
            await _repo.Remove(id);
            return developer;
        }


    }
}