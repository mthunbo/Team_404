using MongoDB.Driver;
using SideQuest.api.Models;

namespace SideQuest.api.Repositories
{
    /// <summary>
    /// Repository responsible for data access operations related to parent users.
    /// </summary>
    public class ParentRepository
    {
        private readonly IMongoCollection<Parent> _parents;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParentRepository"/> class.
        /// </summary>
        /// <param name="db">The MongoDB database instance.</param>
        public ParentRepository(IMongoDatabase db)
        {
            _parents = db.GetCollection<Parent>("Parents");
        }

        /// <summary>
        /// Retrieves a parent user by its unique identifier.
        /// </summary>
        /// <param name="parentId">The ID of the parent user.</param>
        /// <returns>The parent user if found; otherwise null.</returns>
        public Task<Parent> GetById(string parentId) =>
            _parents.Find(p => p.UserId == parentId).FirstOrDefaultAsync();

        /// <summary>
        /// Creates a new parent user in the database.
        /// </summary>
        /// <param name="parent">The parent user to create.</param>
        public Task CreateParent(Parent parent) =>
            _parents.InsertOneAsync(parent);

        /// <summary>
        /// Updates an existing parent user in the database.
        /// </summary>
        /// <param name="parent">The parent user with updated data.</param>
        public Task UpdateParent(Parent parent) =>
            _parents.ReplaceOneAsync(p => p.UserId == parent.UserId, parent);

        /// <summary>
        /// Deletes a parent user by its unique identifier.
        /// </summary>
        /// <param name="parentId">The ID of the parent user to delete.</param>
        /// <returns>True if the parent was deleted successfully; otherwise false.</returns>
        public async Task<bool> DeleteParent(string parentId)
        {
            var result = await _parents.DeleteOneAsync(p => p.UserId == parentId);
            return result.DeletedCount > 0;
        }
    }
}
