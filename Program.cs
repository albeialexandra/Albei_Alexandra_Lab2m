using Microsoft.EntityFrameworkCore;
using Albei_Alexandra_Lab2m;
using Albei_Alexandra_Lab2m.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<Albei_Alexandra_Lab2mContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Albei_Alexandra_Lab2mContext")
        ?? throw new InvalidOperationException("Connection string 'Albei_Alexandra_Lab2mContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Albei_Alexandra_Lab2mContext")
        ?? throw new InvalidOperationException("Connection string 'Albei_Alexandra_Lab2mContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
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