using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SideQuest.api.Models.Entities
{

    // The UserBase class of the parent and child user
    public abstract class UserBaseClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId {get; set;} = null!;
        
        [BsonElement("familyId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? FamilyId {get; set;} = null!;

        [BsonElement("passwordHash")]
        public string PasswordHash {get; set;} = null!;

        [BsonElement("userName")]
        public string Username {get; set;} = null!;

        [BsonElement("idToken")]
        public string IdToken {get; set;} = null!;
    }
}