using Microsoft.EntityFrameworkCore;
using NufusKontrol.Data.Classes;

namespace NufusKontrol.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options):base(options)
        {

        }
        public DbSet<People> People { get; set; }
    }
}
