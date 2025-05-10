using Back2Retro.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back2Retro.Dal
{
    internal class Back2RetroDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public Back2RetroDbContext() : base(@"Data Source=.\sqlexpress;Initial Catalog=Back2RetroDb;Integrated Security=True")
        {

        }
    }
}
