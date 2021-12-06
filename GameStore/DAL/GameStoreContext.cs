using System.Collections.Generic;
using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class GameStoreContext : IdentityDbContext<User>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Game>()
                .Property(x => x.Price)
                .HasColumnType("decimal(18,3)");
            
            // builder.Entity<Game>()
            //     .HasData(new Game()
            //     {
            //         Name = "Fortnite", Details = "The battle royale game", Price = 0,
            //         ImageUrl = "../GameStore/Images/fortnite.jpg",
            //         Comments = new List<Comment>(){ new Comment(){Author = }}
            //     });
        }
    }
}