using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RERERE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RERERE.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "admin@pslib.cz",
                Email = "admin@pslib.cz",
                NormalizedEmail = "admin@pslib.cz".ToUpper(),
                NormalizedUserName = "admin@pslib.cz".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                LockoutEnabled = true,
                PhoneNumberConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Heslo123*"),
                SecurityStamp = string.Empty
            }); ;
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "11111111-1111-1111-1111-111111111112",
                UserName = "user@pslib.cz",
                Email = "user@pslib.cz",
                NormalizedEmail = "user@pslib.cz".ToUpper(),
                NormalizedUserName = "user@pslib.cz".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                LockoutEnabled = true,
                PhoneNumberConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Heslo123*"),
                SecurityStamp = string.Empty
            }); ;

            modelBuilder.Entity<Restaurant>().HasData(new Restaurant { Id = 1, Name = "TadyDorebjidlo"});
            modelBuilder.Entity<Restaurant>().HasData(new Restaurant { Id = 2, Name = "TadyneDorebjidlo" });
            modelBuilder.Entity<Restaurant>().HasData(new Restaurant { Id = 3, Name = "TadyhodneDorebjidlo" });
            modelBuilder.Entity<Review>().HasData(new Review { Id = 1, RestaurantId = 1, AuthorEmail = "user@pslib.cz", Content = "fdsoi" });
            modelBuilder.Entity<Review>().HasData(new Review { Id = 2, RestaurantId = 1, AuthorEmail = "user@pslib.cz", Content = "fdsoi1" });
            modelBuilder.Entity<Review>().HasData(new Review { Id = 3, RestaurantId = 1, AuthorEmail = "admin@pslib.cz", Content = "fdsoi2" });
            modelBuilder.Entity<Review>().HasData(new Review { Id = 4, RestaurantId = 2, AuthorEmail = "user@pslib.cz", Content = "fdsoi3" });
            modelBuilder.Entity<Review>().HasData(new Review { Id = 5, RestaurantId = 3, AuthorEmail = "user@pslib.cz", Content = "fdsoi4" });
        }

    }
}
