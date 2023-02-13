using System.Text;
using DocsvisionClientServer.CategoryRequestValidators;
using DocsvisionClientServer.CategoryRequestValidators.CreateEmailValidator;
using DocsvisionClientServer.CategoryRequestValidators.CreateReceiversValidators;
using DocsvisionClientServer.CategoryRequestValidators.CreateSenderValidator;
using DocsvisionClientServer.Commands;
using DocsvisionClientServer.Commands.CreateEmailCommand;
using DocsvisionClientServer.Commands.CreateReceiverCommand;
using DocsvisionClientServer.Commands.CreateSenderCommand;
using DocsvisionClientServer.Requests;
using DocsvisionClientServer.Responses;
using MassTransit;
using Newtonsoft.Json;

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
        services.AddTransient<ICreateSenderValidator, CreateSenderValidator>();
        services.AddTransient<ICreateSenderCommand, CreateSenderCommand>();
        services.AddTransient<ICreateReceiverValidator, CreateReceiverValidator>();
        services.AddTransient<ICreateReceiverCommand, CreateReceiverCommand>();
        
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
            mt.AddRequestClient<CreateSenderRequest>(new Uri("rabbitmq://localhost/createSender"));
            mt.AddRequestClient<CreateReceiverRequest>(new Uri("rabbitmq://localhost/createReceiver"));
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