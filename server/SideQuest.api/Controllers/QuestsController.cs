using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Services;
using SideQuest.api.Models;

namespace server.Controllers{
    
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
        [HttpPost]
        [Authorize(Roles = "Parent")]
        public async Task<IActionResult> CreateQuest(Quest quest)
        {
            var user = await _userService.GetCurrentUserAsync();
            var result = await _questService.CreateQuestAsync(user, quest);
            return Ok(result);
        }
    }
}
