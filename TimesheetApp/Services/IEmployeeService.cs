using TimesheetApp.Models;

namespace TimesheetApp.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee Register(Employee employee);
        Employee Login(string email, string password);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}
