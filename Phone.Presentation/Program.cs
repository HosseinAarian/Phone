using Microsoft.OpenApi;
using Phone.Application.Contract.CommandsQueries.Brands;
using Phone.Application.Handlers.Brands;
using Phone.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Phone", Version = "v1" });
    c.EnableAnnotations();
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateBrandCommandHandler).Assembly);
});

PhoneConfiguration.Configure(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (!PhoneConfiguration.Migrate(app.Services))
    return;

app.Run();


