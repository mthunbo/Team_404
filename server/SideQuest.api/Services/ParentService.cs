using SideQuest.api.Models;
using SideQuest.api.Repositories;

namespace ParentService
{
    public class ParentService
    {
        
        private readonly ParentRepository _parents;

        public ParentService(ParentRepository parents)
        {
            _parents = parents;
        }

        public Task<Parent> GetById(string parentId) =>
            _parents.GetById(parentId);

        public async Task<Parent> CreateParent(Parent parent)
        {
            await _parents.CreateParent(parent);
            return parent;
        }

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

        public Task<bool> Delete(string parentId) =>
            _parents.DeleteParent(parentId);


    }
}