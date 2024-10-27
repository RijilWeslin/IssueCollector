using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using SolutionSphere.API;
using SolutionSphere.Application.IRepository;
using SolutionSphere.Application.IServices;
using SolutionSphere.Application.Services;
using SolutionSphere.Core.Entities;
using SolutionSphere.Infrastructure.Data;
using SolutionSphere.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SolutionSphereDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SolutionSphereConnectionString"));
});
builder.Services.AddMvc(option => option.EnableEndpointRouting = false).AddNewtonsoftJson(
    options => {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    }).AddRazorRuntimeCompilation();

builder.Services.AddTransient<IRepository<Project>, Repository<Project>>();
builder.Services.AddTransient<IRepository<IssueData>, Repository<IssueData>>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<IIssueDataService, IssueDataService>();
builder.Services.AddTransient<DbContext, SolutionSphereDbContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services
 .AddSwaggerGen(c =>
 {     
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "SolutionSphere.API", Version = "v1" });
 }).AddSwaggerGenNewtonsoftSupport()
  .ConfigureSwaggerGen(options =>
  {
      options.DescribeAllParametersInCamelCase();
      options.CustomSchemaIds(x => x.FullName);
  });
;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.ValidatorUrl(null);
    });
}

/*app.UseHttpsRedirection()*/
app.UseMvc();
app.UseStaticFiles();
app.UseRouting();

/*app.UseAuthorization();*/

/*app.MapControllers();*/

app.Run();
