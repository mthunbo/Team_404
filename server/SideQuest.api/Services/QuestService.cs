using SideQuest.api.Models;
using server.Repositories;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace server.Services
{
    public class QuestService{

        private readonly QuestRepository _questRepository;
        
        public QuestService(QuestRepository questRepository)
        {
            _questRepository = questRepository;
        }
        public async Task<Quest> CreateQuestAsync(User user, Quest quest)
        {
            if (user.Role != UserRole.Parent)
                throw new UnauthorizedAccessException();

            await _questRepository.CreateQuestAsync(quest);
            return quest;
        }   
    }
}
