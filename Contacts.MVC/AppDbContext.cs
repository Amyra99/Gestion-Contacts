using Microsoft.EntityFrameworkCore;
using Models;

namespace Contacts.MVC
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Statistic> Statistic { get; set; }
    }
}
