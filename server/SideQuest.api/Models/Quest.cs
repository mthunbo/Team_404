using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// The quest that can be assigned by a parent to a child
public class Quest
{
    // Unique ID identifier
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string QuestId {get; set;} = null!;

    // Id of the user-child that picked the quest
    [BsonElement("assignedChildId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string AssignedChildId {get; set;} = null!;

    // The FamilyId tells which group the quest belongs to
    [BsonElement("familyId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string FamilyId {get; set;} = null!;

    // Title of the quest
    [BsonElement("title")]
    public string Title {get; set;} = null!;

    // Optional description of the quest
    [BsonElement("description")]
    public string? Description {get; set;}

    // The duedate of the quest
    [BsonElement("dueDate")]
    public DateTime? DueDate {get; set;}

    // The date for creating the quest
    [BsonElement("createdAt")]
    public DateTime? CreatedAt {get; set;}

    // Specifies whether the parent wants the quest to be repeated
    [BsonElement("repeating")]
    public bool Repeating {get; set;}

    // Specifies if/how often the quest should be repeated
    [BsonElement("repeatInterval")]
    public int? RepeatInterval {get; set;}

    // Tells the state of the quest
    public enum StateOfQuest
        {
            NotStarted,
            InProgress,
            Completed,
            Canceled    
        } 

    [BsonElement("questState")]
    [BsonRepresentation(BsonType.String)]
    public StateOfQuest QuestState {get; set;}

}