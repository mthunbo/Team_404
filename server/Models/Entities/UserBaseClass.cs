using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// The UserBase class of the parent and child user
public abstract class UserBase
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public String UserId {get; set;} = null!;
    
    [BsonElement("familyId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public String FamilyId {get; set;}

    [BsonElement("passwordHash")]
    public String PasswordHash {get; set;} = null!;

    [BsonElement("userName")]
    public String Username {get; set;} = null!;

    [BsonElement("idToken")]
    public String IdToken {get; set;} = null!;
}