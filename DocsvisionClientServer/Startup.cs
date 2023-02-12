using DocsvisionClientServer.CategoryRequestValidators;
using DocsvisionClientServer.CategoryRequestValidators.CreateEmailValidator;
using DocsvisionClientServer.Commands;
using DocsvisionClientServer.Commands.CreateEmailCommand;
using DocsvisionClientServer.Requests;
using MassTransit;

namespace DocsvisionClientServer;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<ICreateEmailValidator, CreateEmailValidator>();
        services.AddTransient<ICreateEmailCommand, CreateEmailCommand>();
        
        services.AddControllers();

        services.AddMassTransit(mt =>
        {
            mt.UsingRabbitMq((context, config) =>
            {
                config.Host("localhost", "/", host =>
                {
                    host.Username("guest");
                    host.Password("guest");
                });
            });
            mt.AddRequestClient<CreateEmailRequest>(new Uri("rabbitmq://localhost/createEmail"));
        });
        services.AddMassTransitHostedService();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}