using MongoDB.Driver;
using SideQuest.api.Models;

namespace SideQuest.api.Repositories
{
    public class FamilyRepository
    {
        private readonly IMongoCollection<Family> _family;

        public FamilyRepository(IMongoDatabase database)
        {
            _family = database.GetCollection<Family>("Family");
        }

        /// <summary>
        /// Creates a new Family in the database.
        /// </summary>
        /// <param name="family">The Family to create.</param>
        /// <returns>The created Family.</returns>
        public async Task<Family> CreateFamily(Family family)
        {
            await _family.InsertOneAsync(family);
            return family;
        }

        /// <summary>
        /// Retrieves a family by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the family.</param>
        /// <returns>The family if found; otherwise null.</returns>
        public async Task<Family?> GetById(string id)
        {
            return await _family.Find(g => g.FamilyId == id).FirstOrDefaultAsync();
        }

        public async Task UpdateFamily(Family family)
        {
            var result = await _family.ReplaceOneAsync(
                f => f.FamilyId == family.FamilyId, family,
                new ReplaceOptions { IsUpsert = false }
);
        }

        /// <summary>
        /// Deletes a family by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the family to delete.</param>
        /// <returns>True if the family was deleted successfully; otherwise false.</returns>
        public async Task<bool> DeleteFamily(string id)
        {
            var result = await _family.DeleteOneAsync(g => g.FamilyId == id);
            return result.DeletedCount > 0;
        }


    }
}