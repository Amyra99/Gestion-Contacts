 
using Microsoft.EntityFrameworkCore;
using Models;

namespace Contacts.MVC
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base() { }
        public string ligne { get; set; }
    }
}
