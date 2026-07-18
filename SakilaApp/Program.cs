using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SakilaApp.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using SakilaApp.Services;
using SakilaApp.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<SakilaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("IdentityConnection")));

builder.Services
    .AddIdentityCore<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Password.RequiredLength = 6;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = Microsoft.AspNetCore.Identity.IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = Microsoft.AspNetCore.Identity.IdentityConstants.ApplicationScheme;
    })
    .AddCookie(Microsoft.AspNetCore.Identity.IdentityConstants.ApplicationScheme)
    .AddCookie(Microsoft.AspNetCore.Identity.IdentityConstants.ExternalScheme)
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
    });

builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddTransient<IEmailSender, GmailEmailSender>();

builder.Services.Configure<PayPhoneSettings>(
    builder.Configuration.GetSection("PayPhone"));

builder.Services.AddHttpClient<PayPhoneApiLinkService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    await DbSeeder.SeedAsync(scope.ServiceProvider);
}

app.Run();