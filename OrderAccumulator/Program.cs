using OrderAccumulator.API.ViewModels;
using OrderAccumulator.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ApiMapperProfile));
DependencyInjection.RegisterConfigurations(builder.Services, builder.Configuration);
DependencyInjection.RegisterServices(builder.Services);
DependencyInjection.RegisterAdapters(builder.Services);
DependencyInjection.RegisterProjectAdapters(builder.Services, builder.Configuration);


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
