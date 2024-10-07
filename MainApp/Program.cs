using MainApp.ExtansionMethods;
using MainApp.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddRegister(builder);
var app = builder.Build();
app.MapControllers();
app.UseMiddleware<RequestMiddleware>();
app.UseRouting();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();

