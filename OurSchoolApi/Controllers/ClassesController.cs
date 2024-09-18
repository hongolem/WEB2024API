using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OurSchoolApi.Data;
using OurSchoolApi.Models;

namespace OurSchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly ILogger<ClassesController> _logger;
        private readonly SchoolDbContext _context;
        public ClassesController(
            SchoolDbContext context, 
            ILogger<ClassesController> logger)
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

        [Authorize]
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

        [HttpGet("{id}/students")]
        public async Task<IActionResult> GetStudents(int id)
        {
            _logger.LogInformation($"Get students in class with id {id}");
            var classroom = await _context.Classrooms
                .Include(x => x.Students)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
            if (classroom == null)
            {
                return NotFound("classroom not found");
            }
            return Ok(classroom.Students);
        }
    }
}
