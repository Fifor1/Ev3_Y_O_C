using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Ev3_Y_O_C.Data
{
    public class AspWebContext : DbContext
    {
        public AspWebContext(DbContextOptions<AspWebContext> options) : base(options)
        {
        }

        public DbSet<Ev3_Y_O_C.Models.Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}