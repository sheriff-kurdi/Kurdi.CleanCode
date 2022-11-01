
using Kurdi.CleanCode.Core.Contracts;
using Kurdi.CleanCode.Infrastructure.Data;
using Kurdi.CleanCode.Infrastructure.DataAccess;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IStockItemsRepo, StockItemsRepo>();
builder.Services.AddScoped<IEmployeesRepo, EmployeesSqliteRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();