using Microsoft.EntityFrameworkCore;
using TaskManagerServiceASP.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("MSSQL");
builder.Services.AddDbContext<TaskManagerDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

// Проверка подключения к базе данных
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<TaskManagerDbContext>();
    Console.WriteLine(dbContext.Database.CanConnect()
        ? "Подключение к базе данных успешно."
        : "Не удалось подключиться к базе данных.");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Manager");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();