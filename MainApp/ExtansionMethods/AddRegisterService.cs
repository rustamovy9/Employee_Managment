using MainApp.DataContext;
using MainApp.Entities;
using MainApp.Services;
using Microsoft.EntityFrameworkCore;

namespace MainApp.ExtansionMethods;

public static class AddRegisterService
{
    public static void AddRegister(this IServiceCollection serviceCollection, WebApplicationBuilder builder)
    {
        serviceCollection.AddScoped<IEmployeeService,EmployeeService>();
        serviceCollection.AddDbContext<WebAppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    }
}