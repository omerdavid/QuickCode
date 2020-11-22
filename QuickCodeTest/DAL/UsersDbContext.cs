using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickCodeTest.DAL
{
    public class UsersDbContext:DbContext
    {
        public DbSet<Users> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=qk.db");

        public UsersDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
