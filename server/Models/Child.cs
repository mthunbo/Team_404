using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// The child/normal user
public class ParentModel : UserBase
{
    // The quest id of the quest the child-user picked
    [BsonElement("assignedQuestId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public String AssignedQuestId {get; set;} = null!;

    // The FamilyId that the child-user belongs to.
    [BsonElement("familyId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public String FamilyId {get; set;} =null!;

    // The amount of coins the child has
    [BsonElement("coins")]
    public int Coins {get; set;} = null!;
    
    // The amount of coins the child has used
    [BsonElement("coinsUsed")]
    public int CoinsUsed {get; set;} = null!;

    // Total coins earned by the child
    [BsonElement("coinsTotal")]
    public int CoinsTotal {get; set;} = null!;

    // The login token of the child-user
    [BsonElement("loginToken")]
    public String LoginToken {get; set;} = null!;
}