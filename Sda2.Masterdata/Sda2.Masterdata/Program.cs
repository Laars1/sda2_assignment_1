using Microsoft.EntityFrameworkCore;
using Sda2.Masterdata.Abstractions;
using Sda2.Masterdata.Persistance;
using Sda2.Masterdata.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Register Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepostiory>();
builder.Services.AddScoped<ICustomerInfoRepository, CustomerInfoRepository>();
builder.Services.AddScoped<IStoreRepository, StoresRepository>();
builder.Services.AddScoped<IRegisterRepository, RegisterTableRepository>();

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
