using API_MongoDB2.Data;
using API_MongoDB2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace API_MongoDB2.Services
{
    public class ProdutoServices
    {
        private readonly IMongoCollection<Produto> _produtoCollection;

        public ProdutoServices(IOptions<DatabaseSettings> produtoServices)
        {

            var mongoClient = new MongoClient(produtoServices.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(produtoServices.Value.DatabaseName);

            _produtoCollection = mongoDatabase.GetCollection<Produto>("Produto");

        }

        public async Task<List<Produto>> GetAsync() =>
            await _produtoCollection.Find(pd => true).ToListAsync();

        public async Task<Produto> GetOneAsync(string id) =>
            await _produtoCollection.Find(pd => pd.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Produto produto) =>
            await _produtoCollection.InsertOneAsync(produto);

        public async Task Update(string id, Produto produto)
        {
            var filter = Builders<Produto>.Filter
                .Eq(produto => produto.Id, id);
            var update = Builders<Produto>.Update
                .Set(pr => pr.Nome, produto.Nome);
            await _produtoCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteAsync(string id) =>
            await _produtoCollection.DeleteOneAsync(pd => pd.Id == id);

    }
}
