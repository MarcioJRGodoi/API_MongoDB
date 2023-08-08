using MongoDB.Bson.Serialization.Attributes;

namespace API_MongoDB2.Models
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Nome")]
        public string Nome { get; set; }

        public Produto(string nome)
        {
            Nome = nome;
        }

        public void Atualizar(string nome)
        {
            Nome = nome;
        }
    }
}
