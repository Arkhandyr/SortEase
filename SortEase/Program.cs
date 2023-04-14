using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;
using SortEase;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        LoggerProviderOptions.RegisterProviderOptions<EventLogSettings, EventLogLoggerProvider>(services);

        services.AddWindowsService(options =>
        {
            options.ServiceName = ".NET Directory Sort Service";
        });
        services.AddHostedService<WindowsBackgroundService>();
        services.AddSingleton<WindowsBackgroundService>();
        services.AddTransient<SortService>();

        builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
    })
    .Build();

host.Run();
