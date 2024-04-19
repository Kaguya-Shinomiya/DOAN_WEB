using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using DOAN_WEB.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
AddCookie(options =>
{
	options.Cookie.Name = "DOAN_WEB";
	options.LoginPath = "/User/Login";
});

var connectionString =
builder.Configuration.GetConnectionString("WebsiteQLNSConnection");
builder.Services.AddDbContext<MhDaWContext>(options =>
 options.UseSqlServer(connectionString));

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

app.UseAuthentication();

app.UseAuthorization();




app.UseEndpoints(endpoints =>
{
	//Dashboard

	_ = endpoints.MapControllerRoute(
	 name: "dashboard",
	 pattern: "dashboard",
	 defaults: new { controller = "EmployeeManagement", action = "Index" });

	_ = endpoints.MapControllerRoute(
	 name: "activities",
	 pattern: "activities",
	 defaults: new { controller = "EmployeeManagement", action = "Activities" });

	_ = endpoints.MapControllerRoute(
	 name: "index-employee",
	 pattern: "index-employee",
	 defaults: new { controller = "EmployeeManagement", action = "IndexEmployee" });

	//Employee

	_ = endpoints.MapControllerRoute(
	 name: "employees",
	 pattern: "employees",
	 defaults: new { controller = "Employees", action = "Employees" });

	_ = endpoints.MapControllerRoute(
	 name: "add-employee",
	 pattern: "add-employee",
	 defaults: new { controller = "Employees", action = "AddEmployee" });

	_ = endpoints.MapControllerRoute(
	 name: "employee-grid",
	 pattern: "employee-grid",
	 defaults: new { controller = "Employees", action = "EmployeeGrid" });

	_ = endpoints.MapControllerRoute(
	 name: "employee-office",
	 pattern: "employee-office",
	 defaults: new { controller = "Employees", action = "EmployeeOffice" });

	_ = endpoints.MapControllerRoute(
	 name: "employee-team",
	 pattern: "employee-team",
	 defaults: new { controller = "Employees", action = "EmployeeTeam" });

	//Company

	_ = endpoints.MapControllerRoute(
	 name: "company",
	 pattern: "company",
	 defaults: new { controller = "Company", action = "Company" });

	//Calendar

	_ = endpoints.MapControllerRoute(
	 name: "calendar",
	 pattern: "calendar",
	 defaults: new { controller = "Calendar", action = "Calendar" });

	//Leave

	_ = endpoints.MapControllerRoute(
	 name: "leave",
	 pattern: "leave",
	 defaults: new { controller = "Leave", action = "Leave" });

	//Review

	_ = endpoints.MapControllerRoute(
	 name: "review",
	 pattern: "review",
	 defaults: new { controller = "Review", action = "Review" });

	_ = endpoints.MapControllerRoute(
	 name: "add-review",
	 pattern: "add-review",
	 defaults: new { controller = "Review", action = "AddReview" });

	_ = endpoints.MapControllerRoute(
	 name: "review-type",
	 pattern: "review-type",
	 defaults: new { controller = "Review", action = "ReviewType" });

	//Report

	_ = endpoints.MapControllerRoute(
	 name: "report",
	 pattern: "report",
	 defaults: new { controller = "Report", action = "Report" });

	_ = endpoints.MapControllerRoute(
	 name: "leave-report",
	 pattern: "leave-report",
	 defaults: new { controller = "Report", action = "LeaveReport" });

	_ = endpoints.MapControllerRoute(
	 name: "payroll-report",
	 pattern: "payroll-report",
	 defaults: new { controller = "Report", action = "PayrollReport" });

	_ = endpoints.MapControllerRoute(
	 name: "contact-report",
	 pattern: "contact-report",
	 defaults: new { controller = "Report", action = "ContactReport" });

	_ = endpoints.MapControllerRoute(
	 name: "email-report",
	 pattern: "email-report",
	 defaults: new { controller = "Report", action = "EmailReport" });

	_ = endpoints.MapControllerRoute(
	 name: "security-report",
	 pattern: "security-report",
	 defaults: new { controller = "Report", action = "SecurityReport" });


	_ = endpoints.MapControllerRoute(
	 name: "personal-report",
	 pattern: "personal-report",
	 defaults: new { controller = "Report", action = "PersonalReport" });

	_ = endpoints.MapControllerRoute(
	 name: "Wfh-report",
	 pattern: "Wfh-report",
	 defaults: new { controller = "Report", action = "WfhReport" });

	//Manage

	_ = endpoints.MapControllerRoute(
	 name: "manage",
	 pattern: "manage",
	 defaults: new { controller = "Manage", action = "Manage" });

	_ = endpoints.MapControllerRoute(
	 name: "leadership-manage",
	 pattern: "leadership-manage",
	 defaults: new { controller = "Manage", action = "LeadershipManage" });

	_ = endpoints.MapControllerRoute(
	 name: "super-admin",
	 pattern: "super-admin",
	 defaults: new { controller = "Manage", action = "SuperAdmin" });

	//Setting

	_ = endpoints.MapControllerRoute(
	 name: "settings",
	 pattern: "settings",
	 defaults: new { controller = "Settings", action = "Settings" });

	_ = endpoints.MapControllerRoute(
	 name: "settings-timeoff",
	 pattern: "settings-timeoff",
	 defaults: new { controller = "Settings", action = "SettingsTimeoff" });
	//Profile

	_ = endpoints.MapControllerRoute(
	 name: "profile",
	 pattern: "profile",
	 defaults: new { controller = "Profile", action = "Profile" });

	_ = endpoints.MapControllerRoute(
	 name: "profile-detail",
	 pattern: "profile-detail",
	 defaults: new { controller = "Profile", action = "ProfileDetail" });

	_ = endpoints.MapControllerRoute(
	 name: "profile-document",
	 pattern: "profile-document",
	 defaults: new { controller = "Profile", action = "ProfileDocument" });

	_ = endpoints.MapControllerRoute(
	 name: "profile-create-document",
	 pattern: "profile-create-document",
	 defaults: new { controller = "Profile", action = "ProfileCreatedocument" });

	_ = endpoints.MapControllerRoute(
	 name: "profile-payroll",
	 pattern: "profile-payroll",
	 defaults: new { controller = "Profile", action = "ProfilePayroll" });

	_ = endpoints.MapControllerRoute(
	name: "profile-timeoff",
	pattern: "profile-timeoff",
	defaults: new { controller = "Profile", action = "ProfileTimeoff" });

	_ = endpoints.MapControllerRoute(
	 name: "profile-review",
	 pattern: "profile-review",
	 defaults: new { controller = "Profile", action = "ProfileReview" });

	_ = endpoints.MapControllerRoute(
	 name: "profile-setting",
	 pattern: "profile-setting",
	 defaults: new { controller = "Profile", action = "ProfileSetting" });

	//User

	_ = endpoints.MapControllerRoute(
	 name: "dang-xuat",
	 pattern: "dang-xuat",
	 defaults: new { controller = "User", action = "Logout" });

	//Default

	_ = endpoints.MapControllerRoute(
	name: "default",
	pattern: "{controller=User}/{action=Login}/{id?}");



});


app.Run();
