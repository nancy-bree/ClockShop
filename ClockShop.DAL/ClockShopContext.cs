using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockShop.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ClockShop.DAL
{
    public class ClockShopContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<CardRating> CardRatings { get; set; }
        public DbSet<CommentRating> CommentRatings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        public ClockShopContext() : base(nameOrConnectionString: "ClockShop")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .HasMany(x => x.CardRatings)
                .WithRequired(x => x.Card);

            modelBuilder.Entity<Comment>()
                .HasMany(x => x.CommentRatings)
                .WithRequired(x => x.Comment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Card>()
                .HasMany(x => x.Tags)
                .WithMany(y => y.Cards)
                .Map(x =>
                {
                    x.MapLeftKey("CardId");
                    x.MapRightKey("TagId");
                    x.ToTable("CardTag");
                });

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public static ClockShopContext Create()
        {
            return new ClockShopContext();
        } 
    }
}
