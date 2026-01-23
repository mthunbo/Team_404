using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class ParentModel
{
    // The ID of the rewards
    [BsonElement("rewardId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public String RewardId {get; set;} = null!;

    // Name of the reward
    [BsonElement("name")]
    public String Name {get; set;} = null!;
    
    // Description of the reward
    [BsonElement("description")]
    public String Description {get; set;}

    // How expensive the reward is
    [BsonElement("coinCost")]
    public int CoinCost {get; set;} = null!;

    // The possible states that the reward can have
    public enum RewardState
        {
            NotStarted,
            InProgress,
            Completed,
            Canceled    
        } 

    [BsonElement("rewardState")]
    [BsonRepresentation(BsonType.String)]
    public RewardState RewardState {get; set;} = !null;

    // Determines the reward type. If this is set, the reward becomes a pool that can be jointly contributed towards.
    [BsonElement("rewardPool")]
    public int RewardPool {get; set;}
}