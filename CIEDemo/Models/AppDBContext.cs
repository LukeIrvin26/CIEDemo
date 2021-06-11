using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIEDemo.Models
{
    public class AppDBContext : DbContext
    {
        // this model is used by EF to dictate how and what should be used when creating migrations
        private readonly DbContextOptions _options;
        
        // use the config passed during the injection in startup
        public AppDBContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        // here you define the models that will be used for table values
        public DbSet<Movie> movies { get; set; }

        // if logic was ever needed to do something before the model hasn't been bound to the context yet, it would be here
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}
