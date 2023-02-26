using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartHome.Api;
using SmartHome.Api.Attributes;
using SmartHome.Dao.Dao;
using SmartHome.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOptions();
builder.Services.Configure<Params>(builder.Configuration.GetSection("Params"));
builder.Services.AddControllers();
builder.Services.AddDbContext<SmartHomeContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")), ServiceLifetime.Transient);


builder.Services.AddSwaggerGen(options => {
    options.OperationFilter<SwaggerHeaderFilter>();    
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IUoW, UoW>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
