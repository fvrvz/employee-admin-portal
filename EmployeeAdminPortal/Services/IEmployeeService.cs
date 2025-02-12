using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Services
{
    public interface IEmployeeService
    {
        List<EmployeeEntity> GetAllEmployees();

        EmployeeEntity? GetEmployeeById(Guid id);

        EmployeeEntity AddEmployee(EmployeeDTO request);

        EmployeeEntity? UpdateEmployeeById(Guid id, EmployeeDTO request);

        bool DeleteEmployeeById(Guid id);
    }
}
