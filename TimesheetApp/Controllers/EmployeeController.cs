using Microsoft.AspNetCore.Mvc;
using TimesheetApp.Models;
using TimesheetApp.Services;

namespace TimesheetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        // Register still accepts Employee directly
        [HttpPost("register")]
        public IActionResult Register([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest("Invalid data");

            _service.Register(employee);
            return Ok("Registration successful");
        }

        // Login now uses DTO
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            if (dto == null) return BadRequest("Invalid data");

            var emp = _service.Login(dto.Email, dto.Password);
            if (emp != null)
                return Ok(emp);

            return Unauthorized("Invalid email or password");
        }
    }
}
