public class ParentModel : UserBase
{
    // The quest id of the quest the child-user picked
    [BsonElement("assignedQuestId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public String AssignedQuestId {get; set;} = null!;

    // The amount of coins the child has
    [BsonElement("coins")]
    public int Coins {get; set;} = null!;
    
    // The amount of coins the child has used
    [BsonElement("coinsUsed")]
    public int CoinsUsed {get; set;} = null!;

    // Total coins earned of the child
    [BsonElement("coinsTotal")]
    public int CoinsTotal {get; set;} = null!;

    // The login token of the user
    [BsonElement("loginToken")]
    public String LoginToken {get; set;} = null!;
}