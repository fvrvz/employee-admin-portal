using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    // localhost:xxxx/api/v1/Employees
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = this._employeeService.GetAllEmployees();
            return Ok(allEmployees);
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeDTO request) 
        {
            var employee = this._employeeService.AddEmployee(request);
            return CreatedAtAction(nameof(GetEmployeeById), new {id = employee.Id}, employee.Id);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = this._employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, EmployeeDTO request) 
        {
            var employee = this._employeeService.UpdateEmployeeById(id, request);
            if (employee == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee.Id);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id) 
        {
            var isDeleted = this._employeeService.DeleteEmployeeById(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
