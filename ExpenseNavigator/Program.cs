using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ExpenseNavigator.Data;
using ExpenseNavigator.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ExpenseNavigatorDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ExpenseNavigatorDbContextConnection' not found.");

builder.Services.AddDbContext<ExpenseNavigatorDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ExpenseNavigatorDbContext>();

// See the changes of the HTML File without stopping the project
builder.Services.AddMvc().AddRazorRuntimeCompilation();

// Add services to the container.
builder.Services.AddControllersWithViews();

// add service to support resister
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
