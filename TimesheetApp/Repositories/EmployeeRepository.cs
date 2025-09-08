using TimesheetApp.Data;
using TimesheetApp.Models;

namespace TimesheetApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }
        public Employee GetByEmail(string email)
        {
            return _context.Employees.FirstOrDefault(e => e.Email == email);
        }
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
        public void Add(Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
        }

        public void Update(Employee employee) 
        {
            _context.Employees.Update(employee); 
        }
        public void Delete(int id) 
        {
            var emp = _context.Employees.Find(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
