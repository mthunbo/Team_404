using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// The family is the group of the parent and child users
public class Parent
{
    // The ID of the family group
    [BsonElement("familyId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public String FamilyId {get; set;} = null!;

    // A list of the different quest IDs
    [BsonElement("questId")]
    public List<> QuestId {get; set;}
    
    // The amount of coins the child-user has used
    [BsonElement("admin")]
    public String Admin {get; set;} = null!;

    [BsonElement("childId")]
    public List<> childId {get; set;}

    // The login token of the child-user
    [BsonElement("name")]
    public String Name {get; set;} = null!;

    // A list of the different reward IDs
    [BsonElement("rewardId")]
    public List<> RewardId {get; set;}
}