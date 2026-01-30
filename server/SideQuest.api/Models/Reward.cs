using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SideQuest.api.Models
{

    // The rewards a child-user can pick between
    public class Reward
    {
        // The ID of the rewards
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RewardId {get; set;} = null!;

        // The FamilyId tells which group the reward belongs to
        [BsonElement("familyId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FamilyId {get; set;} = null!;

        // Name of the reward
        [BsonElement("name")]
        public string Name {get; set;} = null!;
        
        // Description of the reward
        [BsonElement("description")]
        public string? Description {get; set;}

        // How expensive the reward is
        [BsonElement("coinCost")]
        public int? CoinCost {get; set;} = null!;

        // Tells the state of the reward
        public enum StateOfReward
            {
                NotStarted,
                InProgress,
                Completed,
                Canceled    
            } 

        [BsonElement("rewardState")]
        [BsonRepresentation(BsonType.String)]
        public StateOfReward RewardState {get; set;}

        // Determines the reward type. If this is true, the reward becomes a pool that can be jointly contributed towards.
        [BsonElement("isPool")]
        public bool IsPool {get; set;}

        // How much is currently contributed towards the reward pool

        [BsonElement("rewardPoolAmount")]
        public int? RewardPoolAmount {get; set;}

        // How much needs to be contributed towards the reward pool

        [BsonElement("rewardPoolGoal")]
        public int? RewardPoolGoal {get; set;}
    }
}