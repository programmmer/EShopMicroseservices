var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCarter();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(async (config) =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCarter();

// Configure the HTTP request pipeline.



app.Run();
