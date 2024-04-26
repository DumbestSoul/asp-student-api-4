using Microsoft.EntityFrameworkCore;
using NewStudent.Business.Business;
using NewStudent.Business.Contract;
using NewStudent.Entity.Models;
using NewStudent.Repository.Contract;
using NewStudent.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Connection injection
builder.Services.AddDbContext<NewStudentContext>(
	options => options.UseSqlServer(
		builder.Configuration.GetConnectionString("DefaultConnection")
		)
	);

//DEPENDECY INJECTION
builder.Services.AddScoped<DbContext, NewStudentContext>();
builder.Services.AddScoped<INewStudentRepository, NewStudentRepository>();
builder.Services.AddScoped<INewStudentBusiness, NewStudentBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
