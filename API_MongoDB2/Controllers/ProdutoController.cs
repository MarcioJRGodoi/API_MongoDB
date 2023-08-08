using API_MongoDB2.Models;
using API_MongoDB2.Models.InputModel;
using API_MongoDB2.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

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
        public async Task<Produto> Get(string id)
        {
            return await _produtoServices.GetOneAsync(id);
             
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public async Task<Produto> Post([FromBody] Produto newProduto)
        {
            var produto = new Produto(newProduto.Nome);
            await _produtoServices.CreateAsync(produto);
            return produto;
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public async void Put(string id, [FromBody] Produto updateProduto)
        {
            await _produtoServices.Update(id, updateProduto);          
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
