using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Services;
using SideQuest.api.Models;

namespace server.Controllers{
    
    /// <summary>
    /// Controller for managing quests.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class QuestController : ControllerBase 
    {
        private readonly UserService _userService;
        private readonly QuestService _questService;

        public QuestController(UserService userService, QuestService questService)
        {
            _userService = userService;
            _questService = questService;
        }

        /// <summary>
        /// Creates a new quest.
        /// </summary>
        /// <param name="quest">The quest to create.</param>
        /// <returns>The created quest.</returns>
        /// <response code="200">Returns the newly created quest</response>

        [HttpPost]
        [Authorize(Roles = "Parent")]
        public async Task<IActionResult> Create(Quest quest)
        {
            var user = await _userService.GetCurrentUserAsync();
            var result = await _questService.ServiceUpdateQuest(user, quest);
            return Ok(result);
        }
    }
}
