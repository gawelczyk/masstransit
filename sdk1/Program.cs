
using sdk1;

var builder = WebApplication.CreateBuilder();




builder.Services.AddHostedService<PingPublisher>();


var app = builder.Build();

app.Run();
    
