using DocsvisionWebApp.Consumer;
using MassTransit;

namespace DocsvisionWebApp;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddMassTransit(mt =>
        {
            mt.AddConsumer<CreateEmailConsumer>();
            mt.AddConsumer<CreateSenderConsumer>();
            mt.AddConsumer<CreateReceiverConsumer>();
            
            mt.UsingRabbitMq((context, config) =>
            {
                config.Host("localhost", "/", host =>
                {
                    host.Username("guest");
                    host.Password("guest");
                });
                config.ReceiveEndpoint("createEmail", ep => ep.ConfigureConsumer<CreateEmailConsumer>(context));
                config.ReceiveEndpoint("createSender", ep => ep.ConfigureConsumer<CreateSenderConsumer>(context));
                config.ReceiveEndpoint("createReceiver", ep => ep.ConfigureConsumer<CreateReceiverConsumer>(context));
            });
        });
        services.AddMassTransitHostedService();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}