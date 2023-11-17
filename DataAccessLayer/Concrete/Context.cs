using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.; database=BlogDemoDB; integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(x => x.FromWriter)
                .WithMany(y => y.FromWr)
                .HasForeignKey(z => z.FromId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.ToWriter)
                .WithMany(y => y.ToWr)
                .HasForeignKey(z => z.ToId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<BlogRating> BlogRatings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
