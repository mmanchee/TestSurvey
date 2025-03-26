using TestSurvey.BusinessLogic;
using TestSurvey.Abstractions.Services;
using TestSurvey.Abstractions.Data;
using TestSurvey.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

// Register our N‑Tier dependencies.
builder.Services.AddTransient<ISurveyService, SurveyService>();
builder.Services.AddSingleton<ISurveyRepository, SurveyRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.MapRazorPages();

app.Run();
