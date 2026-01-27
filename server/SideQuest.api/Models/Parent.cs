using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
<<<<<<< HEAD
=======
using SideQuest.api.Models.Entities;

namespace SideQuest.api.Models;
>>>>>>> feature/namespace

// The parent/admin user
public class Parent : UserBaseClass
{
    // Email of the parent user
    [BsonElement("email")]
    public string Email {get; set;} = null!;

    // Birthdate of the parent user
    [BsonElement("birthdate")]
<<<<<<< HEAD
    public DateTime? Birthdate {get; set;} = null!;
=======
    public DateTime Birthdate {get; set;}
>>>>>>> feature/namespace
}