using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SideQuest.api.Models.Entities;

namespace SideQuest.api.Models
{

    // The parent/admin user
    public class Parent : UserBaseClass
    {
        // Email of the parent user
        [BsonElement("email")]
        public string Email {get; set;} = null!;

        // Birthdate of the parent user
        [BsonElement("birthdate")]
        public DateTime Birthdate {get; set;}
    }
}