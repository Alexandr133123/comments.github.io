using Comments.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace Comments.Infrastructure.DbContexts
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FileStorage> FileStorage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.HasIndex(e => e.UserName).IsClustered(false).IsUnique();
                entity.HasIndex(e => e.Email).IsClustered(false).IsUnique();
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.HasOne(e => e.User)
                    .WithMany(e => e.Comments)
                    .HasForeignKey("CommentUserId");
                

                entity.HasOne(e => e.HeadComment)
                    .WithMany(e => e.Answers)
                    .HasForeignKey("HeadCommentId")
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<FileStorage>(entity =>
            {
                entity.HasKey(e => e.FileId);

                entity.HasOne(e => e.Comment)
                .WithMany(e => e.Files)
                .HasForeignKey(e => e.CommentId);

                entity.Property(e => e.FileData)
                .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }


    }
}
