using homework_api.Models;
using Microsoft.EntityFrameworkCore;

namespace homework_api.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Values> Values { get; set; }
    }
}