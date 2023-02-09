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
        services.AddControllers();

        services.AddMassTransit(mt =>
        {
            // mt.AddConsumer<CreateCategoryConsumer>();
            // mt.AddConsumer<FindCategoryConsumer>();

            mt.UsingRabbitMq((context, config) =>
            {
                config.Host("localhost", "/", host =>
                {
                    host.Username("guest");
                    host.Password("guest");
                });
                // config.ReceiveEndpoint("createCategory", ep => ep.ConfigureConsumer<CreateCategoryConsumer>(context));
                // config.ReceiveEndpoint("findCategory", ep => ep.ConfigureConsumer<FindCategoryConsumer>(context));
            });
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