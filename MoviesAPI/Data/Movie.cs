using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesAPI.Data
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Summary { get; set; } = null;
        public List<string> Actors { get; set; }

        public BsonDocument UnstructuredInfo { get; set; }
    }
}
