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

        public async Task UpdateQuest(Quest quest)
        {
            var result = await _quest.ReplaceOneAsync(f => f.QuestId == quest.QuestId, quest,
            new ReplaceOptions { IsUpsert = false } );
        } 

        public async Task CreateQuest(Quest quest)
        {
            await _quest.InsertOneAsync(quest);
        }
        

    }
}