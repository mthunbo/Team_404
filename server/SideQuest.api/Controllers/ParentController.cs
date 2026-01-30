using Microsoft.AspNetCore.Mvc;
using SideQuest.api.Models;
using SideQuest.api.Services;

namespace SideQuest.api.Controllers
{
    /// <summary>
    /// Controller for managing parent users.
    /// </summary>
    [ApiController]
    [Route("api/parents")]
    public class ParentController : ControllerBase
    {
        private readonly ParentService _parents;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParentController"/> class.
        /// </summary>
        /// <param name="parents">The parent service instance.</param>
        public ParentController(ParentService parents)
        {
            _parents = parents;
        }

        /// <summary>
        /// Creates a new parent user.
        /// </summary>
        /// <param name="parent">The parent user to create.</param>
        /// <returns>The created parent user.</returns>
        /// <response code="200">Returns the newly created parent</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Parent parent)
        {
            var created = await _parents.CreateParent(parent);
            return Ok(created);
        }

        /// <summary>
        /// Retrieves a parent user by its unique identifier.
        /// </summary>
        /// <param name="parentId">The ID of the parent user.</param>
        /// <returns>The matching parent user.</returns>
        /// <response code="200">Returns the parent</response>
        /// <response code="404">If the parent was not found</response>
        [HttpGet("{parentId}")]
        public async Task<IActionResult> GetById(string parentId)
        {
            var parent = await _parents.GetById(parentId);
            return parent is null ? NotFound() : Ok(parent);
        }

        /// <summary>
        /// Updates an existing parent user.
        /// </summary>
        /// <param name="parentId">The ID of the parent user to update.</param>
        /// <param name="email">The new email address (optional).</param>
        /// <param name="birthdate">The new birthdate (optional).</param>
        /// <returns>No content if the update was successful.</returns>
        /// <response code="204">Parent was updated successfully</response>
        /// <response code="404">If the parent was not found</response>
        [HttpPut("{parentId}")]
        public async Task<IActionResult> Update(
            string parentId,
            [FromQuery] string? email,
            [FromQuery] DateTime? birthdate)
        {
            var ok = await _parents.Update(parentId, email, birthdate);
            return ok ? NoContent() : NotFound();
        }

        /// <summary>
        /// Deletes a parent user by its unique identifier.
        /// </summary>
        /// <param name="parentId">The ID of the parent user to delete.</param>
        /// <returns>No content if the deletion was successful.</returns>
        /// <response code="204">Parent was deleted successfully</response>
        /// <response code="404">If the parent was not found</response>
        [HttpDelete("{parentId}")]
        public async Task<IActionResult> Delete(string parentId)
        {
            var ok = await _parents.Delete(parentId);
            return ok ? NoContent() : NotFound();
        }
    }
}