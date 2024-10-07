using MainApp.Entities;

namespace MainApp.Services;

public interface IEmployeeService
{
    Task<bool> CreateEmployeeAsync(Employee employee); 
    Task<bool> UpdateEmployeeAsync(Employee employee); 
    Task<bool> DeleteEmployeeAsync(Guid id); 
    Task<Employee?> GetEmployeeByIdAsync(Guid id); 
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<IEnumerable<Employee>> SelectAllEmployeesAsync();
    Task<Employee?> SelectEmployeeByIdAsync(Guid id); 
    Task<IEnumerable<Employee>> SelectEmployeeByDepartmentNameAsync(string departmentName);
    Task<IEnumerable<Employee>> SelectEmployeeIsActiveAsync(bool isActive);
    Task<EmployeeSalaryStatistics> SelectEmployeeSalaryStatisticsAsync();
    Task<IEnumerable<Employee>> SelectEmployeeByBirthOfDateAsync(DateTime startDate, DateTime endDate);
}