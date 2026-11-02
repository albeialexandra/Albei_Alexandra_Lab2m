using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Albei_Alexandra_Lab2m.Data;

public class LibraryIdentityContext : IdentityDbContext<IdentityUser>
{
    public LibraryIdentityContext(DbContextOptions<LibraryIdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}