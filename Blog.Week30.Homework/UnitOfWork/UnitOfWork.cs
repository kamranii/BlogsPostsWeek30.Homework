using System;
using Blog.Week30.Homework.Data;
using Blog.Week30.Homework.Repository.Abstractions;
using Blog.Week30.Homework.Repository.Implementations;
using Microsoft.EntityFrameworkCore;

namespace Blog.Week30.Homework.UnitOfWork
{
	public class UnitOfWork: IUnitOfWork
	{
        public IBlogRepository blogRepository { get; set; }
        public IPostRepository postRepository { get; set; }

        private readonly ApplicationDbContext _dbContext;

		public UnitOfWork(ApplicationDbContext dbContext)
		{
            _dbContext = dbContext;
            blogRepository = new BlogRepository(_dbContext);
            postRepository = new PostRepository(_dbContext);
        }

        public async Task Commit(CancellationToken cancellationToken = new CancellationToken())
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

