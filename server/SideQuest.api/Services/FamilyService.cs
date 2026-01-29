using SideQuest.api.Models;
using SideQuest.api.Repositories;

namespace SideQuest.api.Services
{  
    public class FamilyService
    {
        private readonly FamilyRepository _familyRepository;
        // private readonly ChildRepository _childRepository;
        // private readonly QuestRepository _questRepository;

        public FamilyService(FamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }

        /// <summary>
        /// Creates a family with the Name given and the creating parent as Admin.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="adminUserId"></param>
        /// <returns>Returns the created family</returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Family> CreateFamily(string name, string adminUserId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Family name is required.", nameof(name));

            if (string.IsNullOrWhiteSpace(adminUserId))
                throw new ArgumentException("Admin is required.", nameof(adminUserId));

            var family = new Family
            {
                Name = name.Trim(),
                Admin = adminUserId.Trim(),
                ChildIds = [],
                QuestIds = [],
                RewardIds = []
            };

            return await _familyRepository.CreateFamily(family);
        }
        /// <summary>
        /// Gets a family by ID
        /// </summary>
        /// <param name="familyId"></param>
        /// <returns>Returns the family witht the given ID</returns>
        /// <exception cref="ArgumentException"></exception>
        public Task<Family?> GetById(string familyId)
        {
            if (string.IsNullOrWhiteSpace(familyId))
                throw new ArgumentException("FamilyId is required.", nameof(familyId));

            return _familyRepository.GetById(familyId);
        }

        /// <summary>
        /// Updates only allowed fields (currently Name and Admin).
        /// This avoids "overwrite everything" problems.
        /// </summary>
        public async Task<bool> UpdateFamily(string familyId, string? newName, string? newAdminUserId)
        {
            if (string.IsNullOrWhiteSpace(familyId))
                throw new ArgumentException("FamilyId is required.", nameof(familyId));

            var existing = await _familyRepository.GetById(familyId);
            if (existing is null) return false;

            // Only update fields that were provided
            if (!string.IsNullOrWhiteSpace(newName))
                existing.Name = newName.Trim();

            if (!string.IsNullOrWhiteSpace(newAdminUserId))
                existing.Admin = newAdminUserId.Trim();

            await _familyRepository.UpdateFamily(existing);
            return true;
        }

        /// <summary>
        /// Deletes the family with the given ID, and all children quests and rewards belonging to said family
        /// </summary>
        /// <param name="familyId"></param>
        /// <returns>True if family was deleted otherwise false</returns>
        /// <exception cref="ArgumentException"></exception>
        public Task<bool> DeleteFamily(string familyId)
        {
            if (string.IsNullOrWhiteSpace(familyId))
                throw new ArgumentException("FamilyId is required.", nameof(familyId));

/*             var family = _familyRepository.GetById(familyId);
            foreach (var childId in family.Children ?? Enumerable.Empty<string>())
            {
                await _childRepository.Delete(childId);
            }

            foreach (var questId in family.Quests ?? Enumerable.Empty<string>())
            {
                await _questRepository.Delete(questId);
            }

            foreach (var rewardId in family.Rewards ?? Enumerable.Empty<string>())
            {
                await _rewardRepository.Delete(rewardId);
            } */

            return _familyRepository.DeleteFamily(familyId);
        }
    }
}