namespace MainApp.SqlCommand;

public class SqlCommand
{
    public const string ConnectionString = "Server=127.0.0.1;Port=5432;Database=employee_management_db;User Id=postgres;Password=123456;";
    public const string SelectAllEmployees = "SELECT * FROM \"Employees\";";
    public const string SelectEmployeeById = "Select * From \"Employees\" WHERE \"Id\"=@Id";
    public const string SelectEmployeeIsActive = "Select * From \"Employees\" WHERE \"IsActive\"=@IsActive";

    public const string SelectEmployeeByDepartmentName =
        "SELECT * FROM \"Employees\" WHERE \"DepartmentName\"=@DepartmentName";

    public const string SelectEmployeeSalaryStatistics =
        " SELECT min(\"Salary\") AS MinSalary,max(\"Salary\") AS MaxSalary,avg(\"Salary\") AS AvgSalary,sum(\"Salary\") AS TotalSalaries\nFROM \"Employees\";";

    public const string SelectEmployeeByBirthOfDateStartDateAndEndDate = "SELECT * \n    FROM \"Employees\"" +
                                                                         " WHERE \"DateOfBirth\" BETWEEN @StartDate AND @EndDate;";
}