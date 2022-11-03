
using Kurdi.CleanCode.Core.Contracts;
using Kurdi.CleanCode.Infrastructure.Data;
using Kurdi.CleanCode.Infrastructure.DataAccess;
using Kurdi.CleanCode.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<StockItemService>();
builder.Services.AddScoped<IStockItemsRepo, StockItemsRepo>();
builder.Services.AddScoped<IEmployeesRepo, EmployeesSqliteRepo>();
builder.Services.AddCors();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(cors => { cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });

app.UseHttpsRedirection();
app.MapControllers();

app.Run();