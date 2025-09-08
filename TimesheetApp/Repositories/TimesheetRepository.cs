using Microsoft.EntityFrameworkCore;
using TimesheetApp.Data;
using TimesheetApp.Models;

namespace TimesheetApp.Repositories
{
    public class TimesheetRepository : ITimesheetRepository
    {
        private readonly AppDbContext _context;

        public TimesheetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Timesheet>> GetAll()
        {
            return await _context.Timesheets.Include(t => t.Employee).ToListAsync();
        }

        public async Task<Timesheet> GetById(int id)
        {
            return await _context.Timesheets.Include(t => t.Employee).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Timesheet>> GetByEmployeeId(int employeeId)
        {
            return await _context.Timesheets
                .Include(t => t.Employee)
                .Where(t => t.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<Timesheet> Add(Timesheet timesheet)
        {
            _context.Timesheets.Add(timesheet);
            await _context.SaveChangesAsync();
            return timesheet;
        }

        public async Task<Timesheet> Update(Timesheet timesheet)
        {
            _context.Timesheets.Update(timesheet);
            await _context.SaveChangesAsync();
            return timesheet;
        }

        public async Task<bool> Delete(int id)
        {
            var ts = await _context.Timesheets.FindAsync(id);
            if (ts == null) return false;

            _context.Timesheets.Remove(ts);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
