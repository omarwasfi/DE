using System.Reflection;
using DE.Server.DBContext;
using DE.Server.Services.Classes;
using DE.Server.Services.Interfaces;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var DEDatabaseConnectionString = builder.Configuration.GetConnectionString("DEConnectionString");

builder.Services.AddDbContext<DEDbContext>(options =>
              options
              .UseMySql(
                   DEDatabaseConnectionString,
                   ServerVersion.AutoDetect(DEDatabaseConnectionString)
                  ));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IStoredFile, StoredFile>();
builder.Services.AddScoped<IAsset, Asset>();
builder.Services.AddScoped<IPicture, Picture>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CM API",
        Description = "The server side api",
        TermsOfService = new Uri("https://omarwasfi.com"),
        Contact = new OpenApiContact
        {
            Name = "Omar Wasfi",
            Email = "contact@omwasfi.com",
            Url = new Uri("https://omarwasfi.com"),
        },
        License = new OpenApiLicense
        {
            Name = "Use under LICX",
            Url = new Uri("https://omarwasfi.com"),
        }
    });

    
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
});


app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");



app.Run();

