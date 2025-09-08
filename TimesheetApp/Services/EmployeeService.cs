using TimesheetApp.Models;
using TimesheetApp.Repositories;

namespace TimesheetApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo) => _repo = repo;

        public IEnumerable<Employee> GetAllEmployees() => _repo.GetAll();
        public Employee GetEmployee(int id) => _repo.GetById(id);

        public Employee Register(Employee emp)
        {
            // Check if email already exists
            var existing = _repo.GetByEmail(emp.Email);
            if (existing != null) return null;

            _repo.Add(emp);
            return emp;
        }


        public Employee Login(string email, string password)
        {
            var emp = _repo.GetByEmail(email);
            Console.WriteLine($"DEBUG: DB Password = {emp?.Password}, Entered Password = {password}");
            return emp != null && emp.Password == password ? emp : null;
        }



        public void UpdateEmployee(Employee employee) { _repo.Update(employee); _repo.Save(); }
        public void DeleteEmployee(int id) { _repo.Delete(id); _repo.Save(); }
    }
}
