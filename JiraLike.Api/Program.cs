var builder = WebApplication.CreateBuilder(args);

// Register Startup 
var startup = new JiraLike.Api.Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();
