using System;
using Blog.Week30.Homework.Data;
using Blog.Week30.Homework.Entities;
using Blog.Week30.Homework.Repository.Abstractions;

namespace Blog.Week30.Homework.Repository.Implementations
{
	public class BlogRepository: Repository<SBlog, int>, IBlogRepository
	{
		public BlogRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
		}
	}
}

