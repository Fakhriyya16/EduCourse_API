using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Educations;
using Service.Services.Interfaces;

namespace EduCourse_API.Controllers
{
    public class EducationController : BaseController
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _educationService.GetAllWithAsync();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> SearchByName([FromQuery] string name)
        {
            var data = await _educationService.GetByName(name);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> SortByName([FromQuery] string message)
        {
            var data = await _educationService.SortByName(message);
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EducationCreateDto request)
        {
            await _educationService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { response = "Data successfully created" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _educationService.GetByIdAsync(id));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null) return BadRequest();
            await _educationService.DeleteAsync((int)id);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] EducationEditDto request)
        {
            await _educationService.EditAsync(id, request);
            return Ok();
        }
    }
}

