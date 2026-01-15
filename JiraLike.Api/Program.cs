using Serilog;

var builder = WebApplication.CreateBuilder(args);

// ✅ Correct Serilog integration (Docker-safe)
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext();
});

// ✅ REQUIRED for Docker (bind to container port)
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080);
});

// ✅ Register Startup (PASS ENVIRONMENT)
var startup = new JiraLike.Api.Startup(
    builder.Configuration,
    builder.Environment);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

// ✅ Configure middleware pipeline
startup.Configure(app);

app.Run();
