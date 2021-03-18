using backend_week5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_week5.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<User> User { get; set; }
    }
}
