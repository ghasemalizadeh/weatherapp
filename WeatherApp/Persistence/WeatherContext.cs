using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Dto;
using WeatherApp.Model;

namespace WeatherApp.Persistence
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Country>()
           //     .HasKey(c => new { c.ID, c.LicensePlate });
        }

        //Location tables
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<WeatherApp.Model.TimeZone> TimeZones { get; set; }
        public DbSet<AdministrativeArea> AdministrativeAreas { get; set; }

        //Forcast tables
        public DbSet<FiveDaysForcast> FiveDaysForcasts { get; set; }






    }
}
