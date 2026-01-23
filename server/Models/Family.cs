public class ParentModel
{
    // The ID of the family group
    [BsonElement("familyId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public String FamilyId {get; set;} = null!;

    // A list of the different quest IDs
    [BsonElement("questId")]
    public List<> QuestId {get; set;}
    
    // The amount of coins the child has used
    [BsonElement("admin")]
    public String Admin {get; set;} = null!;

    [BsonElement("childId")]
    public List<> childId {get; set;}

    // The login token of the user
    [BsonElement("name")]
    public String Name {get; set;} = null!;

    [BsonElement("rewardId")]
    public List<> RewardId {get; set;}
}