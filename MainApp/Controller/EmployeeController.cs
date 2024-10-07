using MainApp.Entities;
using MainApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MainApp.Controller;

[ApiController]
[Route("api/employees")]
public class EmployeeController:ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        this._employeeService = employeeService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeesAsync()
    {
        return Ok(await _employeeService.GetAllEmployeesAsync());
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Employee>> GetEmployeeByIdAsync(Guid id)
    {
        Employee? employee = await _employeeService.GetEmployeeByIdAsync(id);
        return employee is null? NotFound("Employee not found") : Ok(employee);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Employee>> CreateEmployeeAsync([FromBody] Employee? employee)
    {
        if (employee==null)
            return BadRequest("Employee cannot be null");

        return Ok(await _employeeService.CreateEmployeeAsync(employee));
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Employee>> UpdateEmployeeAsync([FromBody] Employee? employee)
    {
        if (employee == null)
            return BadRequest("Employee cannot be null");

        bool updatedEmployee = await _employeeService.UpdateEmployeeAsync(employee);
        return updatedEmployee is false ? NotFound("Employee not found") : Ok(updatedEmployee);
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteEmployeeAsync(Guid id)
    {
        bool deletedEmployee = await _employeeService.DeleteEmployeeAsync(id);
        return deletedEmployee is false? NotFound("Employee not found") : Ok(deletedEmployee);
    }
    
    [HttpGet("/api/employees/all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Employee>>> SelectAllEmployeesAsync()
    {
        return Ok(await _employeeService.SelectAllEmployeesAsync());
    }
    
    [HttpGet("api/employees/details/{id:guid}\"")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Employee>>> SelctEmployeesById(Guid id)
    {
        return Ok(await _employeeService.SelectEmployeeByIdAsync(id));
    }

    [HttpGet("/api/employees-isActive={isActive:bool}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Employee>>> SelectEmployeesByActive(bool isActive)
    {
        return Ok(await _employeeService.SelectEmployeeIsActiveAsync(isActive));
    }

    [HttpGet("/api/employees/department/{departmentName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Employee>>> SelectEmployeesByDepartmentName(string? departmentName)
    {
        
        return departmentName is null ? BadRequest("Заполните поле") :Ok(await _employeeService.SelectEmployeeByDepartmentNameAsync(departmentName));
    }
    
    [HttpGet("/api/employees/salary-statistics")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<EmployeeSalaryStatistics>> SelectSalaryStatisticsAsync()
    {
        return Ok(await _employeeService.SelectEmployeeSalaryStatisticsAsync());
    }
    
    [HttpGet("/api/employees/birthdays-startDate={startDate:datetime}&endDate={endDate:datetime}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<Employee>>> SelectEmployeesByBirthdays(DateTime startDate, DateTime endDate)
    {
        return Ok(await _employeeService.SelectEmployeeByBirthOfDateAsync(startDate, endDate));
    }
}