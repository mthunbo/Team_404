using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// The rewards a child-user can pick between
public class ParentModel
{
    // The ID of the rewards
    [BsonElement("rewardId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public String RewardId {get; set;} = null!;

    // The FamilyId tells which group the reward belongs to
    [BsonElement("familyId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public String FamilyId {get; set;} = null!;

    // Name of the reward
    [BsonElement("name")]
    public String Name {get; set;} = null!;
    
    // Description of the reward
    [BsonElement("description")]
    public String Description {get; set;}

    // How expensive the reward is
    [BsonElement("coinCost")]
    public int CoinCost {get; set;} = null!;

    // Tells the state of the reward
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

    // Determines the reward type. If this is true, the reward becomes a pool that can be jointly contributed towards.
    [BsonElement("isPool")]
    public Boolean IsPool {get; set;}

    // How much is currently contributed towards the reward pool

    [BsonElement("rewardPoolAmount")]
    public int RewardPoolAmount {get; set;}

    // How much needs to be contributed towards the reward pool

    [BsonElement("rewardPoolGoal")]
    public int RewardPoolGoal {get; set;}
}