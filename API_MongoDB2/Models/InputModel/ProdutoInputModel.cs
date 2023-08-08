using MongoDB.Bson.Serialization.Attributes;

namespace API_MongoDB2.Models.InputModel
{
    public class ProdutoInputModel
    {
        [BsonElement("Nome")]
        public string Nome { get; set; }


    }
}
