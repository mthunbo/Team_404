using SideQuest.api.Models;
using SideQuest.api.Repositories;

namespace SideQuest.api.Services
{
    /// <summary>
    /// Service responsible for business logic related to parent users.
    /// </summary>
    public class ParentService
    {
        private readonly ParentRepository _parents;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParentService"/> class.
        /// </summary>
        /// <param name="parents">The parent repository instance.</param>
        public ParentService(ParentRepository parents)
        {
            _parents = parents;
        }

        /// <summary>
        /// Retrieves a parent user by its unique identifier.
        /// </summary>
        /// <param name="parentId">The ID of the parent user.</param>
        /// <returns>The parent user if found; otherwise null.</returns>
        public Task<Parent> GetById(string parentId) =>
            _parents.GetById(parentId);

        /// <summary>
        /// Creates a new parent user.
        /// </summary>
        /// <param name="parent">The parent user to create.</param>
        /// <returns>The created parent user.</returns>
        public async Task<Parent> CreateParent(Parent parent)
        {
            await _parents.CreateParent(parent);
            return parent;
        }

        /// <summary>
        /// Updates an existing parent user.
        /// </summary>
        /// <param name="parentId">The ID of the parent user to update.</param>
        /// <param name="email">The new email address (optional).</param>
        /// <param name="birthdate">The new birthdate (optional).</param>
        /// <returns>True if the update was successful; otherwise false.</returns>
        public async Task<bool> Update(string parentId, string? email, DateTime? birthdate)
        {
            var parent = await _parents.GetById(parentId);
            if(parent is null) return false;

            if(!string.IsNullOrWhiteSpace(email))
                parent.Email = email;

            if(birthdate.HasValue)
                parent.Birthdate = birthdate.Value;

            await _parents.UpdateParent(parent);
            return true;
        }

        /// <summary>
        /// Deletes a parent user by its unique identifier.
        /// </summary>
        /// <param name="parentId">The ID of the parent user to delete.</param>
        /// <returns>True if the parent was deleted successfully; otherwise false.</returns>
        public Task<bool> Delete(string parentId) =>
            _parents.DeleteParent(parentId);
    }
}