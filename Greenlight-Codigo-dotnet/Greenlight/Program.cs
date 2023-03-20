using Greenlight.Data.Applications;
using Greenlight.Data.Configurations.Configure;
using Greenlight.Data.Configurations.ConfigureServices;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureServices();

var app = builder.Build();
var environment = app.Environment;
app.Configure(environment);
app.MapControllers();
app.Run();
