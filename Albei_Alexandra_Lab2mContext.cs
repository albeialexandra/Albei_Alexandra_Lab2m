using Microsoft.EntityFrameworkCore;
using Albei_Alexandra_Lab2m.Models;

namespace Albei_Alexandra_Lab2m
{
    public class Albei_Alexandra_Lab2mContext : DbContext
    {
        public Albei_Alexandra_Lab2mContext(DbContextOptions<Albei_Alexandra_Lab2mContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;
    }
}