using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// The family is the group of the parent and child users
public class Family
{
    // The ID of the family group
    [BsonElement("familyId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public String FamilyId {get; set;} = null!;
    
    // The amount of coins the child-user has used
    [BsonElement("admin")]
    public String Admin {get; set;} = null!;

    // The login token of the child-user
    [BsonElement("name")]
    public String Name {get; set;} = null!;

}