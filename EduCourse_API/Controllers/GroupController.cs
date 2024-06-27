using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Groups;
using Service.Services.Interfaces;

namespace EduCourse_API.Controllers
{
    public class GroupController : BaseController
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _groupService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _groupService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GroupCreateDto request)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            await _groupService.CreateAsync(request);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _groupService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromQuery] int id, [FromBody] GroupEditDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _groupService.EditAsync(id, request);

            return Ok();
        }
    }
}
