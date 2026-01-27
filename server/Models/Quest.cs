using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// The model of the quest assigned by a parent to a child
public class QuestModel
{
    // Unique ID identifier
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public String QuestId {get; set;} = null!;

    // Id of the user-child that picked the quest
    [BsonElement("assignedChildId")]
    [BsonRepresentation(BsonType.ObjectId)]
    public String AssignedChildId {get; set;} = null!;

    // Title of the quest
    [BsonElement("title")]
    public string Title {get; set;} = null!;

    // Optional description of the quest
    [BsonElement("description")]
    public string Description {get; set;}

    // Optional duedate of the quest
    [BsonElement("dueDate")]
    public DateTime DueDate {get; set;} 

    // The date for creating the quest
    [BsonElement("createdAt")]
    public DateTime CreatedAt {get; set;} = null!;

    // Specifies whether the parent wants the quest to be repeated
    [BsonElement("repeating")]
    public Boolean Repeating {get; set;} = null!;

    // Specifies how often the quest should be repeated
    [BsonElement("repeatInterval")]
    public DateTime RepeatInterval {get; set;} = null!;

    // Tells the state of the quest
    public enum QuestState
        {
            NotStarted,
            InProgress,
            Completed,
            Canceled    
        } 

        [BsonElement("questState")]
        [BsonRepresentation(BsonType.String)]
        public QuestState QuestState {get; set;} = !null;

}