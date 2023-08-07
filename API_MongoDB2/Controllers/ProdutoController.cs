using API_MongoDB2.Models;
using API_MongoDB2.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_MongoDB2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase    
    {
        private readonly ProdutoServices _produtoServices;
        public ProdutoController(ProdutoServices produtoServices)
        {
            _produtoServices = produtoServices;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public async Task<List<Produto>> Get() => 
            await _produtoServices.GetAsync();

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public async Task<Produto> Put(Produto produto)
        {
            await _produtoServices.CreateAsync(produto);
            return produto;
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
