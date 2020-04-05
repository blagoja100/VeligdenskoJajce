using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeligdenskoJajce.Model;

namespace VeligdenskoJajce.Data
{
    public class VeligdenskoJajceContext : DbContext
    {
        public VeligdenskoJajceContext (DbContextOptions<VeligdenskoJajceContext> options)
            : base(options)
        {
        }

        public DbSet<VeligdenskoJajce.Model.PlayRoom> PlayRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayRoom>().ToTable("PlayRooms");
        }
    }
}
