using SideQuest.api.Models;
using SideQuest.api.Repositories;

namespace SideQuest.api.Services
{
    /// <summary>
    /// Service responsible for business logic related to child users.
    /// </summary>
    public class ChildService
    {
        private readonly ChildRepository _children;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChildService"/> class.
        /// </summary>
        /// <param name="childRepository">The child repository instance.</param>
        public ChildService(ChildRepository childRepository)
        {
            _children = childRepository;
        }

        /// <summary>
        /// Creates a new child user.
        /// </summary>
        /// <param name="child">The child user to create.</param>
        /// <returns>The created child user.</returns>
        public async Task<Child> CreateChild(Child child)
        {
            await _children.CreateChild(child);
            return child;
        }

        /// <summary>
        /// Retrieves a child user by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the child user.</param>
        /// <returns>The child user if found; otherwise null.</returns>
        public Task<Child> GetById(string id) =>
            _children.GetById(id);

        /// <summary>
        /// Updates the username of an existing child user.
        /// </summary>
        /// <param name="id">The ID of the child user.</param>
        /// <param name="username">The new username.</param>
        /// <returns>True if the update was successful; otherwise false.</returns>
        public async Task<bool> UpdateUsername(string id, string username)
        {
            var child = await _children.GetById(id);
            if (child is null) return false;

            if (!string.IsNullOrWhiteSpace(username))
                child.Username = username;

            return await _children.UpdateChild(child);
        }

        /// <summary>
        /// Adds coins to a child user and updates the total earned coins accordingly.
        /// </summary>
        /// <param name="id">The ID of the child user.</param>
        /// <param name="amount">The number of coins to add.</param>
        /// <returns>True if the coins were added successfully; otherwise false.</returns>
        public async Task<bool> AddCoins(string id, int amount)
        {
            if (amount <= 0) return false;

            var child = await _children.GetById(id);
            if (child is null) return false;

            child.Coins ??= 0;
            child.CoinsTotal ??= 0;

            child.Coins += amount;
            child.CoinsTotal += amount;

            return await _children.UpdateChild(child);
        }

        /// <summary>
        /// Spends coins from a child user and updates the used coins accordingly.
        /// </summary>
        /// <param name="id">The ID of the child user.</param>
        /// <param name="amount">The number of coins to spend.</param>
        /// <returns>True if the coins were spent successfully; otherwise false.</returns>
        public async Task<bool> SpendCoins(string id, int amount)
        {
            if (amount <= 0) return false;

            var child = await _children.GetById(id);
            if (child is null) return false;

            child.Coins ??= 0;
            child.CoinsUsed ??= 0;

            if (child.Coins < amount) return false;

            child.Coins -= amount;
            child.CoinsUsed += amount;

            return await _children.UpdateChild(child);
        }

        /// <summary>
        /// Assigns a quest to a child user.
        /// </summary>
        /// <param name="id">The ID of the child user.</param>
        /// <param name="questId">The ID of the quest to assign.</param>
        /// <returns>True if the quest was assigned successfully; otherwise false.</returns>
        public async Task<bool> AssignQuest(string id, string questId)
        {
            var child = await _children.GetById(id);
            if (child is null) return false;

            if (string.IsNullOrWhiteSpace(questId)) return false;

            child.AssignedQuestId = questId;
            return await _children.UpdateChild(child);
        }

        /// <summary>
        /// Clears the currently assigned quest from a child user.
        /// </summary>
        /// <param name="id">The ID of the child user.</param>
        /// <returns>True if the assigned quest was cleared successfully; otherwise false.</returns>
        public async Task<bool> ClearAssignedQuest(string id)
        {
            var child = await _children.GetById(id);
            if (child is null) return false;

            child.AssignedQuestId = null!;
            return await _children.UpdateChild(child);
        }

        /// <summary>
        /// Deletes a child user by its unique identifier.
        /// </summary>
        /// <param name="childId">The ID of the child user to delete.</param>
        /// <returns>True if the child was deleted successfully; otherwise false.</returns>
        public Task<bool> DeleteChild(string childId) =>
            _children.DeleteChild(childId);
    }
}

