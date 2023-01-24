using DataAccess;
using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Models.Identity;
using Utility;
using Utility.CloudCommunication;
using Utility.CloudCommunication.Interfaces;
using Utility.C2DUpdateEventService.Interfaces;
using Utility.C2DUpdateEventService;

//Function for seeding database with Identity Roles
async Task CreateRoles(IServiceProvider serviceProvider)
{
    RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>(); 

    if(await roleManager.RoleExistsAsync(SD.Admin) == false)
    {
        await roleManager.CreateAsync(new IdentityRole(SD.Admin));
        await roleManager.CreateAsync(new IdentityRole(SD.User));
    }
}

//Function for seeding database with one Super User
async Task CreateSuperUser(IServiceProvider serviceProvider)
{
    ApplicationUser appUser = new ApplicationUser();
    ConfigurationManager config = new ConfigurationManager();
    RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
    config.AddJsonFile("appsettings.json");

    appUser.FirstName = config.GetValue<string>("SuperUserDetails:FirstName");
    appUser.LastName = config.GetValue<string>("SuperUserDetails:LastName");
    appUser.UserName = config.GetValue<string>("SuperUserDetails:Username");
    appUser.Email = config.GetValue<string>("SuperUserDetails:Email");

    var user = await userManager.FindByEmailAsync(config.GetValue<string>("SuperUserDetails:Email"));
    if(user == null)
    {
        IdentityResult superUser = await userManager.CreateAsync(appUser, config.GetValue<string>("SuperUserDetails:Password"));
        if(superUser.Succeeded)
        {
            await userManager.AddToRoleAsync(appUser, SD.Admin);
        } 
    }
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>().AddUserManager<UserManager<IdentityUser>>().AddDefaultUI();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICloudCommunicationService, CloudCommunicationService>();
builder.Services.AddScoped<IC2DUpdateEventService, C2DUpdateEventService>();
builder.Services.AddRazorPages();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await CreateRoles(services);
    await CreateSuperUser(services);
}
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

app.MapControllerRoute(
    name: "default",
    pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
