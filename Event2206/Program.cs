using Event2206.Data;
using Event2206.Data.EF;
using Event2206.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
IronBarCode.License.LicenseKey = "IRONBARCODE.NGUYENTHEKIET2000.17138-A214B7E2E9-E55SBF-HJJ3BL74IXVU-MJAJOWS2ZA7O-5UZDWMDP4FQP-KBIVGUSAKMIM-OOXEKQLNNDIW-VW5T3T-T2ONKJ5FJCOGEA-DEPLOYMENT.TRIAL-IODDAC.TRIAL.EXPIRES.17.JUN.2022";
// Add our Config object so it can be injected
builder.Services.Configure<GlobalAppSetting>(builder.Configuration);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddDbContext<Event2206DbContext>(o =>
o.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddAntDesign();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<Event2206DbContext>();
    dataContext.Database.Migrate();
}

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
