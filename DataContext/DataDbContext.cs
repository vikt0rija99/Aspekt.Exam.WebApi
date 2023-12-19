using Aspekt.Exam.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Aspekt.Exam.WebApi.DataContext
{
    public class AspektDbContext: DbContext
    {
    public AspektDbContext (DbContextOptions options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
