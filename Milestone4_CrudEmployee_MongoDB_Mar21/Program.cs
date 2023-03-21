using MediatR;
using Milestone4_CrudEmployee_MongoDB_Mar21.Interface;
using Milestone4_CrudEmployee_MongoDB_Mar21.Models;
using Milestone4_CrudEmployee_MongoDB_Mar21.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("swagger", builde =>
    {
        builde.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.Configure<EmployeeDatabaseSettings>(
    builder.Configuration.GetSection("EmployeeDatabase"));

builder.Services.AddSingleton<EmployeeRepository>();

builder.Services.AddScoped<IEmployee,EmployeeRepository>();

builder.Services.AddMediatR(typeof(EmployeeRepository).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("swagger");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
