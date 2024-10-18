using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AspWebContext.Data
{
    public class AspWebContext : DbContext
    {
        public AspWebContext(DbContextOptions<AspWebContext> options) : base(options)
        {
        }

        public DbSet<AspWebContext.Models.Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}