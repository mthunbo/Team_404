using Microsoft.AspNetCore.Mvc;
using SideQuest.api.Services;

namespace SideQuest.api.Controllers
{
    /// <summary>
    /// Controller for managing families.
    /// </summary>
    [ApiController]
    [Route("api/families")]
    public class FamilyController : ControllerBase
    {
        private readonly FamilyService _familyService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FamilyController"/> class.
        /// </summary>
        /// <param name="familyService">The family service instance.</param>
        public FamilyController(FamilyService familyService)
        {
            _familyService = familyService;
        }

        /// <summary>
        /// Creates a new family.
        /// </summary>
        /// <param name="name">The name of the family.</param>
        /// <param name="adminUserId">The user ID of the family admin (parent).</param>
        /// <returns>The created family.</returns>
        /// <response code="201">Returns the newly created family</response>
        /// <response code="400">If the input data is invalid</response>
        [HttpPost]
        public async Task<IActionResult> CreateFamily(
            [FromQuery] string name,
            [FromQuery] string adminUserId)
        {
            var family = await _familyService.CreateFamily(name, adminUserId);
            return Ok(family);
        }

        /// <summary>
        /// Retrieves a family by its unique identifier.
        /// </summary>
        /// <param name="familyId">The ID of the family.</param>
        /// <returns>The matching family.</returns>
        /// <response code="200">Returns the family</response>
        /// <response code="404">If the family was not found</response>
        [HttpGet("{familyId}")]
        public async Task<IActionResult> GetFamilyById(string familyId)
        {
            var family = await _familyService.GetById(familyId);
            if (family is null)
                return NotFound();

            return Ok(family);
        }

        /// <summary>
        /// Updates an existing family.
        /// </summary>
        /// <param name="familyId">The ID of the family to update.</param>
        /// <param name="name">The new name of the family (optional).</param>
        /// <param name="adminUserId">The new admin user ID (optional).</param>
        /// <returns>No content if the update was successful.</returns>
        /// <response code="204">Family was updated successfully</response>
        /// <response code="404">If the family was not found</response>
        [HttpPut("{familyId}")]
        public async Task<IActionResult> UpdateFamily(
            string familyId,
            [FromQuery] string? name,
            [FromQuery] string? adminUserId)
        {
            var updated = await _familyService.UpdateFamily(
                familyId,
                name,
                adminUserId);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Deletes a family by its unique identifier.
        /// </summary>
        /// <param name="familyId">The ID of the family to delete.</param>
        /// <returns>No content if the deletion was successful.</returns>
        /// <response code="204">Family was deleted successfully</response>
        /// <response code="404">If the family was not found</response>
        [HttpDelete("{familyId}")]
        public async Task<IActionResult> DeleteFamily(string familyId)
        {
            var deleted = await _familyService.DeleteFamily(familyId);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
