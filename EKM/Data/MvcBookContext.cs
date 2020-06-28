using Microsoft.EntityFrameworkCore;
using EKM.Models;

namespace EKM.Data
{
    public class MvcBookContext : DbContext
    {
        public MvcBookContext (DbContextOptions<MvcBookContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}