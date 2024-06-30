
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Students;
using Service.Services.Interfaces;

namespace EduCourse_API.Controllers
{
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _studentService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _studentService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentCreateDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _studentService.CreateAsync(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromQuery] int id, [FromBody] StudentEditDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _studentService.EditAsync(id, request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _studentService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Filter([FromBody] StudentFilterDto request)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _studentService.Filter(request));
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string nameOrSurname)
        {
            return Ok(await _studentService.SearchAsync(nameOrSurname));
        }

    }
}
