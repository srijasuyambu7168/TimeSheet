using TimesheetApp.Models;

namespace TimesheetApp.Repositories
{
    public interface ITimesheetRepository
    {
        Task<IEnumerable<Timesheet>> GetAll();
        Task<Timesheet> GetById(int id);
        Task<IEnumerable<Timesheet>> GetByEmployeeId(int employeeId);
        Task<Timesheet> Add(Timesheet timesheet);
        Task<Timesheet> Update(Timesheet timesheet);
        Task<bool> Delete(int id);
    }
}
