using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SideQuest.api.Models
    {

    // The family is the group of the parent and child users
    public class Family
    {
        // The ID of the family group
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FamilyId {get; set;} = null!;
        
        // The parent admin account
        [BsonElement("admin")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Admin {get; set;} = null!;

        // Name of the family
        [BsonElement("name")]
        public string Name {get; set;} = null!;

        [BsonElement("children")]
        [BsonRepresentation(BsonType.ObjectId)]
        public List<Child>? Children {get; set;}

        [BsonElement("quests")]
        [BsonRepresentation(BsonType.ObjectId)]
        public List<Quest>? Quests { get; set; }

        [BsonElement("rewards")]
        [BsonRepresentation(BsonType.ObjectId)]
        public List<Reward>? Rewards { get; set; }

    }
}