using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace web_api
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
