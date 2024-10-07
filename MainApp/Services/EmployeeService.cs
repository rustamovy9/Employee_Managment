using Dapper;
using MainApp.DataContext;
using MainApp.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace MainApp.Services;

public class EmployeeService(WebAppDbContext dbContext):IEmployeeService
{
    public async Task<bool> CreateEmployeeAsync(Employee employee)
    {
        try
        {
            await dbContext.Employees.AddAsync(employee);
            return await dbContext.SaveChangesAsync()>0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateEmployeeAsync(Employee employee)
    {
        try
        {
            Employee? existemployee = await dbContext.Employees.FindAsync(employee.Id);
            if (existemployee == null)
                return false;
            existemployee.FirstName = employee.FirstName;
            existemployee.LastName = employee.LastName;
            existemployee.Email = employee.Email;
            existemployee.Phone = employee.Phone;
            existemployee.DateOfBirth = employee.DateOfBirth;
            existemployee.HireDate = employee.HireDate;
            existemployee.Position = employee.Position;
            existemployee.Salary = employee.Salary;
            existemployee.DepartmentName = employee.DepartmentName;
            existemployee.ManagerName = employee.ManagerName;
            existemployee.IsActive = employee.IsActive;
            existemployee.Address = employee.Address;
            existemployee.City = employee.City;
            existemployee.Country = employee.Country;
            existemployee.UpdatedAt = DateTime.Now;
            return await dbContext.SaveChangesAsync()>0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteEmployeeAsync(Guid id)
    {
        try
        {
            var employee = await dbContext.Employees.FindAsync(id);
            if (employee!= null)
            {
                dbContext.Employees.Remove(employee);
                return await dbContext.SaveChangesAsync()>0;
            }

            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
    {
        try
        {
            return await dbContext.Employees.FindAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        try
        {
            return await dbContext.Employees.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Employee>> SelectAllEmployeesAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new (SqlCommand.SqlCommand.ConnectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Employee>(SqlCommand.SqlCommand.SelectAllEmployees);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Employee?> SelectEmployeeByIdAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection conn = new (SqlCommand.SqlCommand.ConnectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<Employee>(SqlCommand.SqlCommand.SelectEmployeeById, new { Id = id });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Employee>> SelectEmployeeByDepartmentNameAsync(string departmentName)
    {
        try
        {
            using (NpgsqlConnection conn = new (SqlCommand.SqlCommand.ConnectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Employee>(SqlCommand.SqlCommand.SelectEmployeeByDepartmentName, new { DepartmentName = departmentName });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Employee>> SelectEmployeeIsActiveAsync(bool isActive)
    {
        try
        {
            using (NpgsqlConnection conn = new (SqlCommand.SqlCommand.ConnectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Employee>(SqlCommand.SqlCommand.SelectEmployeeIsActive, new { IsActive = isActive });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<EmployeeSalaryStatistics> SelectEmployeeSalaryStatisticsAsync()
    {
        try
        {
            using (NpgsqlConnection conn = new (SqlCommand.SqlCommand.ConnectionString))
            {
                await conn.OpenAsync();
                return await conn.QuerySingleAsync<EmployeeSalaryStatistics>(SqlCommand.SqlCommand.SelectEmployeeSalaryStatistics);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async  Task<IEnumerable<Employee>> SelectEmployeeByBirthOfDateAsync(DateTime startDate, DateTime endDate)
    {
        try
        {
            using (NpgsqlConnection conn = new (SqlCommand.SqlCommand.ConnectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<Employee>(SqlCommand.SqlCommand.SelectEmployeeByBirthOfDateStartDateAndEndDate,new {StartDate=startDate ,EndDate=endDate});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

  
}