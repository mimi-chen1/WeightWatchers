using Microsoft.EntityFrameworkCore;
using Serilog;
using WeightWatchers.Config;
using WeightWatchers.data;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;



builder.Services.AddControllers();
builder.Services.ConfigurationService();
builder.Host.UseSerilog((context, configuration) =>
{
      
    configuration.ReadFrom.Configuration(context.Configuration);

});

builder.Services.AddDbContext<WeightWatchersContex>(option =>
{
     
    option.UseSqlServer(configuration.GetConnectionString("WeightWatchersConnectionString"));
}
       );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSerilogRequestLogging();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware(typeof(MiddleWare));

app.Run();
