
using Academia.WebApi.ErrosMiddleware;
using BloodDonationDataBase.Application.Logs;
using BloodDonationDataBase.Extensions.Dependencies;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjection(builder.Configuration);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    //c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Barbearia", Version = "v1" });


    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "V1",
        Title = "Blood donation system",
        Description = " Blood donation database management API, where a donor and their donations can be registered",
        Contact = new OpenApiContact
        {
            Name = "Fabio dos Santos",
            Email = "f.santosdev1992@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/f%C3%A1bio-dos-santos-518612275/")
        }

    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware(typeof(ErroMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.UseFastReport();

app.MapControllers();

app.Run();
