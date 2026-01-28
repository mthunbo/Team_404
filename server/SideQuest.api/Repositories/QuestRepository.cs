using SideQuest.api.Models;
using MongoDB.Driver;
using System.Security.Claims;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata.Ecma335;

namespace server.Repositories
{

    public class QuestRepository
    {
        private readonly IMongoCollection<Quest> _quest;

        public QuestRepository(IMongoDatabase database)
        {
            _quest = database.GetCollection<Quest>("Quest");
        }

        public async Task<Quest> GetById(string id)
        {
            return await _quest.Find(g => g.QuestId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteQuest(string id)
        {
            var result = await _quest.DeleteOneAsync(g => g.QuestId == id);
            return result.DeletedCount > 0;
        }

        public async Task<Quest> UpdateQuest(string id)
        {
            var result = await _quest.ReplaceOneAsync(g => g.QuestId == id);
            new ReplaceOptions (isUpsert = false);
        } 

        public async Task<Quest> CreateQuest(Quest quest)
        {
            await _quest.InsertOneAsync(quest);
        }
        

    }
}