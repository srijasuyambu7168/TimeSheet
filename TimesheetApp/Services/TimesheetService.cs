using TimesheetApp.Models;
using TimesheetApp.Repositories;

namespace TimesheetApp.Services
{
    public class TimesheetService : ITimesheetService
    {
        private readonly ITimesheetRepository _repo;

        public TimesheetService(ITimesheetRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Timesheet>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Timesheet> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<IEnumerable<Timesheet>> GetByEmployeeId(int employeeId)
        {
            return await _repo.GetByEmployeeId(employeeId);
        }

        public async Task<Timesheet> Add(Timesheet timesheet)
        {
            return await _repo.Add(timesheet);
        }

        public async Task<Timesheet> Update(Timesheet timesheet)
        {
            return await _repo.Update(timesheet);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repo.Delete(id);
        }
    }
}
