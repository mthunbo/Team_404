using MongoDB.Driver;
using SideQuest.api.Models;

namespace SideQuest.api.Repositories
{
    /// <summary>
    /// Repository responsible for data access operations related to child users.
    /// </summary>
    public class ChildRepository
    {
        private readonly IMongoCollection<Child> _child;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChildRepository"/> class.
        /// </summary>
        /// <param name="database">The MongoDB database instance.</param>
        public ChildRepository(IMongoDatabase database)
        {
            _child = database.GetCollection<Child>("Child");
        }

        /// <summary>
        /// Creates a new child user in the database.
        /// </summary>
        /// <param name="child">The child user to create.</param>
        /// <returns>The created child user.</returns>
        public async Task<Child> CreateChild(Child child)
        {
            await _child.InsertOneAsync(child);
            return child;
        }

        /// <summary>
        /// Retrieves a child user by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the child user.</param>
        /// <returns>The child user if found; otherwise null.</returns>
        public async Task<Child> GetById(string id)
        {
            return await _child.Find(c => c.UserId == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Updates an existing child user in the database.
        /// </summary>
        /// <param name="child">The child user with updated data.</param>
        /// <returns>True if the update was successful; otherwise false.</returns>
        public async Task<bool> UpdateChild(Child child)
        {
            var result = await _child.ReplaceOneAsync(
                c => c.UserId == child.UserId, child,
                new ReplaceOptions { IsUpsert = false }
            );
            return result.ModifiedCount > 0;
        }

        /// <summary>
        /// Deletes a child user by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the child user to delete.</param>
        /// <returns>True if the child was deleted successfully; otherwise false.</returns>
        public async Task<bool> DeleteChild(string id)
        {
            var result = await _child.DeleteOneAsync(c => c.UserId == id);
            return result.DeletedCount > 0;
        }
    }
}
