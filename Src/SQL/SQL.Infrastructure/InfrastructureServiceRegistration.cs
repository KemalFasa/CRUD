using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
// using SQL.Application.Contracts.Infrastructure;
using SQL.Application.Contracts.Persistence;
// using SQL.Application.Models;
// using SQL.Infrastructure.Mail;
using SQL.Infrastructure.Persistence;
using SQL.Infrastructure.Repositories;

namespace SQL.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddDbContext<OrderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SQLConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));                        
            services.AddScoped<IOrderRepository, OrderRepository>();

            // services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            // services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
