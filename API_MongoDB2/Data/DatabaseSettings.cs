using MongoDB.Driver.Core.Configuration;

namespace API_MongoDB2.Data
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public Dictionary<string, CollectionSettings> Collections { get; set; }

        public class CollectionSettings
        {
            public string CollectionName { get; set; }
        }
    }
}
