using FormulaDatabase.Abstracts;
using FormulaDatabase.Data;
using FormulaDatabase.IService;
using FormulaDatabase.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();
//builder.Services.AddSingleton<WeatherForecastService>();

// call the method ConfigureServices()
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


static void ConfigureServices(IServiceCollection services)
{
	services.AddRazorPages();
	services.AddServerSideBlazor();
	////services.AddSingleton<WeatherForecastService>();
	//services.AddScoped<IStudentService, StudentService>();
	services.AddScoped<Service<Driver, FormulaTeam>, DriverService>();
	services.AddScoped<Service<FormulaTeam, Driver>, TeamService>();
}
