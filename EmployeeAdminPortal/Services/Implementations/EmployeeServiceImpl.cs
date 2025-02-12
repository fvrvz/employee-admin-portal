using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Services.Implementations
{
    public class EmployeeServiceImpl : IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<EmployeeServiceImpl> _logger;

        public EmployeeServiceImpl(ApplicationDbContext dbContext, ILogger<EmployeeServiceImpl> logger)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }

        public List<EmployeeEntity> GetAllEmployees()
        {
            var allEmployees = this._dbContext.Employees.ToList();
            this._logger.LogInformation("Returning all Employees");
            return allEmployees;
        }

        public EmployeeEntity AddEmployee(EmployeeDTO request)
        {
            var employeeEntity = new EmployeeEntity()
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Salary = request.Salary,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

            this._logger.LogInformation("Adding Employee with Name: {}", request.Name);

            this._dbContext.Employees.Add(employeeEntity);
            this._dbContext.SaveChanges();

            return employeeEntity;
        }

        public EmployeeEntity? GetEmployeeById(Guid id)
        {
            var employee = this._dbContext.Employees.Find(id);
            this._logger.LogInformation("Searching employee with ID: {}", id);
            if (employee == null)
            {
                this._logger.LogWarning("Employee not found with ID: {}", id);
                return null;
            }
            return employee;
        }

        public EmployeeEntity? UpdateEmployeeById(Guid id, EmployeeDTO request)
        {
            var employee = this._dbContext.Employees.Find(id);
            this._logger.LogInformation("Searching employee with ID: {}", id);
            if (employee == null)
            {
                this._logger.LogWarning("Employee not found with ID: {}", id);
                return null;
            }

            employee.Name = request.Name;
            employee.Email = request.Email;
            employee.Phone = request.Phone;
            employee.Salary = request.Salary;
            employee.ModifiedAt = DateTime.UtcNow;

            this._logger.LogWarning("Updating employee with ID: {}", id);
            this._dbContext.SaveChanges();

            return employee;
        }

        public bool DeleteEmployeeById(Guid id)
        {
            var employee = this._dbContext.Employees.Find(id);
            this._logger.LogInformation("Searching employee with ID: {}", id);
            if (employee == null)
            {
                this._logger.LogWarning("Employee not found with ID: {}", id);
                return false;
            }

            this._logger.LogWarning("Deleting employee with ID: {}", id);
            this._dbContext.Remove(employee);
            this._dbContext.SaveChanges();

            return true;
        }
    }
}
