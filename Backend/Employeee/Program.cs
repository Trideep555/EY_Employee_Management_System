using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Employeee.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EmployeeeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeeContext") ?? throw new InvalidOperationException("Connection string 'EmployeeeContext' not found.")));

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});
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
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
