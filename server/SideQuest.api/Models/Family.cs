using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SideQuest.api.Models;

// The family is the group of the parent and child users
public class Family
{
    // The ID of the family group
    [BsonElement("familyId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string FamilyId {get; set;} = null!;
    
    // The amount of coins the child-user has used
    [BsonElement("admin")]
    public string Admin {get; set;} = null!;

    // The login token of the child-user
    [BsonElement("name")]
    public string Name {get; set;} = null!;

}