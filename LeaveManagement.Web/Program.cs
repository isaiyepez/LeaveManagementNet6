using LeaveManagement.BusinessLogic.Configurations;
using LeaveManagement.BusinessLogic.Contracts;
using LeaveManagement.Data;
using LeaveManagement.BusinessLogic.Repositories;
using LeaveManagement.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Email
builder.Services.AddTransient<IEmailSender>(s => new EmailSender("localhost", 25, "no-reply@leavemanagement.com"));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//Identity
builder.Services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>();
//Auto Mapper
builder.Services.AddAutoMapper(typeof(MapperConfig));
//HTTP Context Accessor
builder.Services.AddHttpContextAccessor();
//SeriLog
builder.Host.UseSerilog((ctx, lc) => 
	lc.WriteTo.Console()
	.ReadFrom.Configuration(ctx.Configuration));
//Generic Repo
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//Other Repos
builder.Services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
builder.Services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

builder.Services.AddControllersWithViews();

//Allow CORS
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// global cors policy
app.UseCors(x => x
	.AllowAnyMethod()
	.AllowAnyHeader()
	.SetIsOriginAllowed(origin => true) // allow any origin
	.AllowCredentials()); // allow credentials

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
