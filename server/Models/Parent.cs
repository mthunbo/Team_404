using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

// The parent/admin user
public class Parent : UserBase
{
    // Email of the parent user
    [BsonElement("email")]
    public String Email {get; set;} = null!;

    // Birthdate of the parent user
    [BsonElement("birthdate")]
    public DateTime Birthdate {get; set;} = null!;
}