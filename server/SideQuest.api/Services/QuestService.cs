using SideQuest.api.Models;
using server.Repositories;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Globalization;
using SideQuest.api.Repositories;

namespace server.Services
{
    public class QuestService{

        private readonly QuestRepository _questRepository;

        
        public QuestService(QuestRepository questRepository)
        {
            _questRepository = questRepository;
        }
        public async Task<Quest> ServiceCreateQuest(User user, Quest quest)
        {
            if (user.Role != UserRole.Parent)
                throw new UnauthorizedAccessException();
            
            quest.FamilyId = user.FamilyId;

            await _questRepository.CreateQuest(quest);
            return quest;
        }

        public async Task<Quest> ServiceUpdateQuest(User user, Quest updatedQuest)
        {
            var existing = await _questRepository.GetById(updatedQuest.QuestId);
            
            if (existing.FamilyId != user.FamilyId)
                throw new UnauthorizedAccessException();

            await _questRepository.UpdateQuest(updatedQuest);
            return updatedQuest;
        }




    }
}
