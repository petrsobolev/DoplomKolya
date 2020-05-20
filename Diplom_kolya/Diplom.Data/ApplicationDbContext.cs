using Diplom.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Diplom.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CreditCard> creditCard { get; set; }
        public DbSet<Tickets> tickets { get; set; }
        public DbSet<Transport> transport { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tickets>()
                .HasOne(t => t.transport)
                .WithMany(t => t.tickets)
                .HasForeignKey(f => f.transportId);

            modelBuilder.Entity<Tickets>()
                .HasOne(c => c.card)
                .WithMany(t => t.tickets)
                .HasForeignKey(f => f.creditCardId);

        }
    }
}