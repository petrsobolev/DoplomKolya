using Diplom.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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


        public DbSet<User> users;
        public DbSet<CreditCard> creditCards;
        public DbSet<Tickets> tickets;
        public DbSet<Transport> transports;
        public DbSet<TransportStops> TransportStops;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            using (StreamReader fs = new StreamReader("routes.json"))
            {
                var json = fs.ReadToEnd();
                List<Transport> jsonTransport = JsonSerializer.Deserialize<List<Transport>>(json);
                modelBuilder.Entity<Transport>().HasData(jsonTransport);
            }
            using (StreamReader fs = new StreamReader("stops.json"))
            {
                var json = fs.ReadToEnd();
                List<TransportStops> jsonTransportStop = JsonSerializer.Deserialize<List<TransportStops>>(json);
                modelBuilder.Entity<TransportStops>().HasData(jsonTransportStop);
            }

        }
    }
}