using SideQuest.api.Models;
using server.Repositories;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Globalization;
using SideQuest.api.Repositories;
using System.Xml;

namespace server.Services
{
    public class QuestService{

        private readonly QuestRepository _questRepository;

        
        public QuestService(QuestRepository questRepository)
        {
            _questRepository = questRepository;
        }
        public async Task<Quest> ServiceCreateQuest(User user, CreateQuestDto questDto)
        {
            if (user.Role != UserRole.Parent)
                throw new UnauthorizedAccessException();
            
            var quest = new Quest 
            {
                Title = questDto.Title,
                Description = questDto.Description,
                DueDate = questDto.DueDate,
                Repeating = questDto.Repeating,
                RepeatInterval = questDto.RepeatInterval,

            // Questattributes that is autoconfigured - not decided by the parent-user. 
                // A check that ensures the quest familyId is aligned with the users familyId.
                FamilyId = user.FamilyId,
                CreatedAt = DateTime.UtcNow,
                // Default state of the quest:
                QuestState = Quest.StateOfQuest.NotStarted
            };

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

        public async Task<Quest>
        {
            
        }

    }
}
