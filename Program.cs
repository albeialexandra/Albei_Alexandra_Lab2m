using Microsoft.EntityFrameworkCore;
using Albei_Alexandra_Lab2m;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<Albei_Alexandra_Lab2mContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Albei_Alexandra_Lab2mContext")
        ?? throw new InvalidOperationException("Connection string 'Albei_Alexandra_Lab2mContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();