using MongoDB.Driver;
using SideQuest.api.Models;

namespace SideQuest.api.Repositories
{
    public class ParentRepository
    {
        private readonly IMongoCollection<Parent> _parents;

        public ParentRepository(IMongoDatabase db)
        {
            _parents = db.GetCollection<Parent>("Parents");
        }
        public Task<Parent> GetById(string parentId) =>
            _parents.Find(p => p.UserId == parentId).FirstOrDefaultAsync();

        public Task CreateParent(Parent parent) =>
            _parents.InsertOneAsync(parent);

        public Task UpdateParent(Parent parent) =>
            _parents.ReplaceOneAsync(p => p.UserId == parent.UserId, parent);

        public async Task<bool> DeleteParent(string parentId)
        {
            var result = await _parents.DeleteOneAsync(p => p.UserId == parentId);
            return result.DeletedCount > 0;
        }
    }
}