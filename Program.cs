using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using dwdm_pws2_gym.Data;
using dwdm_pws2_gym.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Students");
    //options.Conventions.AllowAnonymousToFolder("/Alunos");
    //options.Conventions.AuthorizePage("/Alunos/Index");
    options.Conventions.AllowAnonymousToPage("/Students/Index");
});

builder.Services.AddDbContext<GymContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("GymContext") ?? throw new InvalidOperationException("Connection string 'GymContext' not found.")));

builder.Services.AddDbContext<GymIdentityDataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("GymIdentityDataContext") ?? throw new InvalidOperationException("Connection string 'GymIdentityDataContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<GymIdentityDataContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

var app = builder.Build();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
