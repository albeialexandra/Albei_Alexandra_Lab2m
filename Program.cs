using Microsoft.EntityFrameworkCore;
using Albei_Alexandra_Lab2m;
using Albei_Alexandra_Lab2m.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Politica de autorizare (pas 11)
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Books");
    options.Conventions.AllowAnonymousToPage("/Books/Index");
    options.Conventions.AllowAnonymousToPage("/Books/Details");
    options.Conventions.AuthorizeFolder("/MemberPages", "AdminPolicy");

    // Sarcina 1
    options.Conventions.AuthorizeFolder("/PublisherPages", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/CategoryPages", "AdminPolicy");
});

builder.Services.AddDbContext<Albei_Alexandra_Lab2mContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Albei_Alexandra_Lab2mContext")
        ?? throw new InvalidOperationException("Connection string 'Albei_Alexandra_Lab2mContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Albei_Alexandra_Lab2mContext")
        ?? throw new InvalidOperationException("Connection string 'Albei_Alexandra_Lab2mContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()   // pas 5
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
