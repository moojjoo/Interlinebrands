using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnCoreMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnCoreMvc.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
