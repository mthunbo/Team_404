using Microsoft.AspNetCore.Mvc;
using SideQuest.api.Models;
using SideQuest.api.Services;

namespace SideQuest.api.Controllers
{
    [ApiController]
    [Route("api/parents")]
    public class ParentController : ControllerBase
    {
        private readonly ParentService _parents;

        public ParentController(ParentService parents)
        {
            _parents = parents;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Parent parent)
        {
            var created = await _parents.CreateParent(parent);
            return Ok(created);
        }

        [HttpGet("{parentId}")]
        public async Task<IActionResult> GetById(string parentId)
        {
            var parent = await _parents.GetById(parentId);
            return parent is null ? NotFound() : Ok(parent);
        }

        [HttpPut("{parentId}")]
        public async Task<IActionResult> Update(
            string parentId,
            [FromBody] string? email,
            [FromBody] DateTime? birthdate)
        {
            var ok = await _parents.Update(parentId, email, birthdate);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{parentId}")]
        public async Task<IActionResult> Delete(string parentId)
        {
            var ok = await _parents.Delete(parentId);
            return ok ? NoContent() : NotFound();
        }
    }
}