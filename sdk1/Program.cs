
using MassTransit;
using sdk1;


var builder = WebApplication.CreateBuilder();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(typeof(Program).Assembly);

    //x.UsingInMemory((context, cfg) => { cfg.ConfigureEndpoints(context); });
    x.UsingGrpc((context, cfg) =>
    {
        cfg.Host(h =>
        {
            h.Host = "127.0.0.1";
            h.Port = 19796;
        });
        cfg.ConfigureEndpoints(context);
    });
});


builder.Services.AddHostedService<PingPublisher>();

var app = builder.Build();

app.Run();

