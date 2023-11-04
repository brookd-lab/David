using DAL.Data;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace APIWIthRepository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductRepository repo,
            ILogger<ProductController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _repo.GetAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _repo.GetByIdAsync(id);
            if (data == null) return Ok();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            var data = await _repo.AddAsync(product);
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _repo.DeleteAsync(id);
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var data = await _repo.UpdateAsync(product);
            return Ok(data);
        }
    }
}