using Microsoft.EntityFrameworkCore;
using PERUSTARS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PERUSTARS.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Artist Entity
            builder.Entity<Artist>().ToTable("Artist");

            /*Aca mejor lo acabamos cuando esten todos porque en la 
             parte de relaciones si pongo solo algunas y mas tarde tenemos
            actualizar de repente se nos olvida poner alguna y gg*/
        }
    }
}
