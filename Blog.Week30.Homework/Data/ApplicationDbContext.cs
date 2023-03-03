using System;
using Blog.Week30.Homework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Week30.Homework.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions options)
			:base(options)
		{
		}
		DbSet<SBlog> blogs { get; set; }
		DbSet<Post> posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			//schema
			modelBuilder.HasDefaultSchema("sample");
			//blog
			modelBuilder.Entity<SBlog>()
				.ToTable("Blog");
			//post
			modelBuilder.Entity<Post>()
				.ToTable("Post");
			modelBuilder.Entity<Post>()
				.Property(p => p.Title).HasMaxLength(150);
			modelBuilder.Entity<Post>()
				.Property(p => p.CreationDate)
				.HasDefaultValueSql("GETDATE()");
			//relationship
			modelBuilder.Entity<Post>()
				.HasOne(p => p.Blog)
				.WithMany(b => b.Posts)
				.HasForeignKey(p => p.BlogId);
        }
    }
}