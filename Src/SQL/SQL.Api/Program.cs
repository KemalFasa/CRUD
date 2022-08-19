using MediatR;
using SQL.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SQL.Infrastructure;
using SQL.Infrastructure.Persistence;
using SQL.API.Extensions;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

              

 builder.Services.AddApplicationServices();
 builder.Services.AddInfrastructureServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program));
//  builder.Services.AddDbContext<OrderContext>();
 builder.Services.AddAutoMapper(typeof(Program));

//   app.MigrateDatabase<OrderContext>((context, services) =>
//                     {
//                         var logger = services.GetService<ILogger<OrderContextSeed>>();
//                         OrderContextSeed
//                             .SeedAsync(context, logger)
//                             .Wait();
//                     })
//                 .Run();

// var context = builder.Services.BuildServiceProvider().GetService<OrderContext>();
// // var context = app.Services.GetRequiredService<OrderContext>();
// context.Database.Migrate();
// var logger = builder.Services.BuildServiceProvider().GetService<ILogger<OrderContextSeed>>();
//                         OrderContextSeed
//                             .SeedAsync(context, logger)
//                             .Wait();


 builder.Services.AddControllers();
var app = builder.Build();


// using (var serviceScope = app.Services.CreateScope())
// {
//    var services = serviceScope.ServiceProvider;
    
//    var dbcontext = services.GetRequiredService<OrderContext>();
//    var conn = dbcontext.Database.GetConnectionString();
// }


// var context = app.Services.GetRequiredService<OrderContext>();
// context.Database.Migrate();

// Configure the HTTP request pdipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

    app.MigrateDatabase<OrderContext>((context, services) =>
                    {
                        var logger = services.GetService<ILogger<OrderContextSeed>>();
                        OrderContextSeed
                            .SeedAsync(context, logger)
                            .Wait();
                    })
                .Run();



