using SolutionSphere.Business.client;
using SolutionSphere.Business.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IMicroserviceRestClient, MicroserviceRestClient>();
builder.Services.AddTransient<IIssueDataService, IssueDataService>();
builder.Services.AddTransient<IProjectsService, ProjectsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
