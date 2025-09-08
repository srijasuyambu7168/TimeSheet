using Microsoft.AspNetCore.Mvc;
using TimesheetApp.Data;
using TimesheetApp.Models;
using TimesheetApp.Repositories;
using TimesheetApp.Services;

namespace TimesheetApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TimesheetController : ControllerBase
    {
        private readonly ITimesheetService _service;

        public TimesheetController(ITimesheetService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ts = await _service.GetById(id);
            if (ts == null) return NotFound();
            return Ok(ts);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetByEmployeeId(int employeeId)
        {
            var ts = await _service.GetByEmployeeId(employeeId);
            return Ok(ts);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Timesheet timesheet)
        {
            if (!ModelState.IsValid)  // <-- add this to catch validation errors
                return BadRequest(ModelState);

            var created = await _service.Add(timesheet);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Timesheet timesheet)
        {
            if (id != timesheet.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _service.Update(timesheet);
            return Ok(updated);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
