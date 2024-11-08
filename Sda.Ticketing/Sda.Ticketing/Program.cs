using Microsoft.EntityFrameworkCore;
using Sda.Ticketing.Abstractions;
using Sda.Ticketing.Persistance;
using Sda.Ticketing.Repositories;
using Sda.Ticketing.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Register Repositories
builder.Services.AddScoped<IGiftCardRepository, GiftCardRepository>();
builder.Services.AddScoped<IReturnTableRepository, ReturnTableRepository>();
builder.Services.AddScoped<ITicketSystemRepository, TicketSystemRepository>();

// Add Httpclient
builder.Services.AddHttpClient();

// Add Httpservices
builder.Services.AddScoped<ITaxHttpService, TaxHttpService>();


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
