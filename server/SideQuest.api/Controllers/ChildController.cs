using Microsoft.AspNetCore.Mvc;
using SideQuest.api.Models;
using SideQuest.api.Services;

namespace SideQuest.api.Controllers
{
    /// <summary>
    /// Controller for managing child users.
    /// </summary>
    [ApiController]
    [Route("api/children")]
    public class ChildController : ControllerBase
    {
        private readonly ChildService _children;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChildController"/> class.
        /// </summary>
        /// <param name="children">The child service instance.</param>
        public ChildController(ChildService children)
        {
            _children = children;
        }

        /// <summary>
        /// Creates a new child user.
        /// </summary>
        /// <param name="child">The child user to create.</param>
        /// <returns>The created child user.</returns>
        /// <response code="200">Returns the newly created child</response>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Child child)
        {
            var created = await _children.CreateChild(child);
            return Ok(created);
        }

        /// <summary>
        /// Retrieves a child user by its unique identifier.
        /// </summary>
        /// <param name="childId">The ID of the child user.</param>
        /// <returns>The matching child user.</returns>
        /// <response code="200">Returns the child user</response>
        /// <response code="404">If the child was not found</response>
        [HttpGet("{childId}")]
        public async Task<IActionResult> GetById(string childId)
        {
            var child = await _children.GetById(childId);
            return child is null ? NotFound() : Ok(child);
        }

        /// <summary>
        /// Updates the username of a child user.
        /// </summary>
        /// <param name="childId">The ID of the child user.</param>
        /// <param name="username">The new username.</param>
        /// <returns>No content if the update was successful.</returns>
        /// <response code="204">Username updated successfully</response>
        /// <response code="404">If the child was not found</response>
        [HttpPut("{childId}/username")]
        public async Task<IActionResult> UpdateUsername(
            string childId,
            [FromQuery] string username)
        {
            var ok = await _children.UpdateUsername(childId, username);
            return ok ? NoContent() : NotFound();
        }

        /// <summary>
        /// Adds coins to a child user.
        /// </summary>
        /// <param name="childId">The ID of the child user.</param>
        /// <param name="amount">The number of coins to add.</param>
        /// <returns>No content if the operation was successful.</returns>
        /// <response code="204">Coins added successfully</response>
        /// <response code="400">If the amount is invalid</response>
        /// <response code="404">If the child was not found</response>
        [HttpPost("{childId}/coins/add")]
        public async Task<IActionResult> AddCoins(
            string childId,
            [FromQuery] int amount)
        {
            var ok = await _children.AddCoins(childId, amount);
            return ok ? NoContent() : BadRequest();
        }

        /// <summary>
        /// Spends coins from a child user.
        /// </summary>
        /// <param name="childId">The ID of the child user.</param>
        /// <param name="amount">The number of coins to spend.</param>
        /// <returns>No content if the operation was successful.</returns>
        /// <response code="204">Coins spent successfully</response>
        /// <response code="400">If the amount is invalid or insufficient funds</response>
        /// <response code="404">If the child was not found</response>
        [HttpPost("{childId}/coins/spend")]
        public async Task<IActionResult> SpendCoins(
            string childId,
            [FromQuery] int amount)
        {
            var ok = await _children.SpendCoins(childId, amount);
            return ok ? NoContent() : BadRequest();
        }

        /// <summary>
        /// Assigns a quest to a child user.
        /// </summary>
        /// <param name="childId">The ID of the child user.</param>
        /// <param name="questId">The ID of the quest to assign.</param>
        /// <returns>No content if the quest was assigned successfully.</returns>
        /// <response code="204">Quest assigned successfully</response>
        /// <response code="404">If the child was not found</response>
        [HttpPut("{childId}/assign-quest")]
        public async Task<IActionResult> AssignQuest(
            string childId,
            [FromQuery] string questId)
        {
            var ok = await _children.AssignQuest(childId, questId);
            return ok ? NoContent() : NotFound();
        }

        /// <summary>
        /// Clears the currently assigned quest from a child user.
        /// </summary>
        /// <param name="childId">The ID of the child user.</param>
        /// <returns>No content if the assigned quest was cleared.</returns>
        /// <response code="204">Assigned quest cleared successfully</response>
        /// <response code="404">If the child was not found</response>
        [HttpPut("{childId}/clear-quest")]
        public async Task<IActionResult> ClearAssignedQuest(string childId)
        {
            var ok = await _children.ClearAssignedQuest(childId);
            return ok ? NoContent() : NotFound();
        }
        
        /// <summary>
        /// Deletes a child user by its unique identifier.
        /// </summary>
        /// <param name="childId">The ID of the child user to delete.</param>
        /// <returns>No content if the deletion was successful.</returns>
        /// <response code="204">child was deleted successfully</response>
        /// <response code="404">If the parent was not found</response>
        [HttpDelete("{childId}")]
        public async Task<IActionResult> Delete(string childId)
        {
            var ok = await _children.DeleteChild(childId);
            return ok ? NoContent() : NotFound();
        }
    }
}
