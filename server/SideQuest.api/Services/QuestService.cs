using server.Models;
using server.Repositories;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace server.Services
{
    public class QuestService{
        public async Task<Quest> CreateQuestAsync(User user, Quest quest)
        {
            if (user.Role != UserRole.Parent)
                throw new UnauthorizedAccessException();

            await _repository.CreateQuestAsync(quest);
            return quest;
        }   
    }
}
