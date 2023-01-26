using FlightCrashSite.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IFlightCrashService, FlightCrashService>(f =>
{
    FlightCrashService flightCrashService = new FlightCrashService("flight-data.csv");
    flightCrashService.Initalize();
    return flightCrashService;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
