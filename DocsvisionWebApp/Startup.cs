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
        // services.AddTransient<ICreateCategoryValidator, CreateCategoryValidator>();
        // services.AddTransient<IFindCategoryValidator, FindCategoryValidator>();
        // services.AddTransient<ICreateCategoryCommand, CreateCategoryCommand>();
        // services.AddTransient<IFindCategoryCommand, FindCategoryCommand>();
        
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
            // mt.AddRequestClient<CreateCategoryRequest>(new Uri("rabbitmq://localhost/createCategory"));
            // mt.AddRequestClient<FindCategoryRequest>(new Uri("rabbitmq://localhost/findCategory"));
        });
        services.AddMassTransitHostedService();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}