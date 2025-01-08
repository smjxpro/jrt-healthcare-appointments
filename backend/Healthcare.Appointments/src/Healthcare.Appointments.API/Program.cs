using Healthcare.Appointments.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigurePipeline(builder.Configuration);

app.Run();