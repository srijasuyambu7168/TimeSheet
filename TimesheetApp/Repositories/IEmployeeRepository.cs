using TimesheetApp.Models;

namespace TimesheetApp.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        Employee GetByEmail(string email);
        IEnumerable<Employee> GetAll();
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
        void Save();
    }
}
