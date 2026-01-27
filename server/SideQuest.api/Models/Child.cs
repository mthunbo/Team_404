using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// The child/normal user
public class Child : UserBaseClass
{
    // The quest id of the quest the child-user picked
    [BsonElement("assignedQuestId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string AssignedQuestId {get; set;} = null!;

    // The amount of coins the child has
    [BsonElement("coins")]
    public int? Coins {get; set;} = null!;
    
    // The amount of coins the child has used
    [BsonElement("coinsUsed")]
    public int? CoinsUsed {get; set;} = null!;

    // Total coins earned by the child
    [BsonElement("coinsTotal")]
    public int? CoinsTotal {get; set;} = null!;

    // The login token of the child-user
    [BsonElement("loginToken")]
    public string LoginToken {get; set;} = null!;
}