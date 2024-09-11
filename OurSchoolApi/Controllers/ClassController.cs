using Microsoft.AspNetCore.Mvc;
using OurSchoolApi.Data;
using OurSchoolApi.Models;

namespace OurSchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ILogger<ClassController> _logger;
        private readonly SchoolDbContext _context;
        public ClassController(
            SchoolDbContext context, 
            ILogger<ClassController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get all classes");
            var classes = _context.Classrooms.ToList();
            return Ok(classes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation($"Get class with id {id}");
            var classroom = _context.Classrooms.Find(id);
            if (classroom == null)
            {
                return NotFound();
            }
            return Ok(classroom);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Classroom classroom)
        {
            _logger.LogInformation($"Create new class with name {classroom.Name}");
            _context.Classrooms.Add(classroom);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = classroom.Id }, classroom);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id) {
            _logger.LogInformation($"Update class with id {id}");
            var classroom = _context.Classrooms.Find(id);
            if (classroom == null)
            {
                return NotFound();
            }
            _context.Classrooms.Update(classroom);
            _context.SaveChanges();
            return Ok(classroom);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"Delete class with id {id}");
            var classroom = _context.Classrooms.Find(id);
            if (classroom == null)
            {
                return NotFound();
            }
            _context.Classrooms.Remove(classroom);
            _context.SaveChanges();
            return Ok();
        }
    }
}
