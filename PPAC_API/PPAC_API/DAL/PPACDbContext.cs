using System;
using Microsoft.EntityFrameworkCore;
using PPAC_API.DAL.Models;

namespace PPAC_API.DAL
{	
        public class PPACDbContext : DbContext
        {
            public PPACDbContext(DbContextOptions<PPACDbContext> options) : base(options)

            { }

            protected override void OnModelCreating(ModelBuilder modelBuilder) { modelBuilder.Entity<PPACModel>().HasNoKey(); } //extension method
            public DbSet<PPACModel> PPAC { get; set; }
        }
    }



