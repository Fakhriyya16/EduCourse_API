using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Teachers;
using Service.Services.Interfaces;

namespace EduCourse_API.Controllers
{
    public class TeacherController : BaseController
    {
        private readonly ITeacherService _teacherService;
        private readonly IGroupService _groupService;

        public TeacherController(ITeacherService teacherService,
                              IGroupService groupService)
        {
            _teacherService = teacherService;
            _groupService = groupService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _teacherService.GetAllWithAsync());
        }

        [HttpGet]
        public async Task<IActionResult> SearchByNameOrSurname([FromQuery] string nameOrSurname)
        {
            var data = await _teacherService.GetByNameOrSurname(nameOrSurname);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> SortByName([FromQuery] string message)
        {
            var data = await _teacherService.SortByName(message);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> SortByAge([FromQuery] string message)
        {
            var data = await _teacherService.SortByAge(message);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> SortBySalary([FromQuery] string message)
        {
            var data = await _teacherService.SortBySalary(message);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeacherCreateDto request)
        {
            await _teacherService.CreateAsync(request);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _teacherService.GetByIdAsync(id));

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();
            await _teacherService.DeleteAsync((int)id);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] TeacherEditDto request)
        {
            await _teacherService.EditAsync(id, request);
            return Ok();
        }
    }
}
