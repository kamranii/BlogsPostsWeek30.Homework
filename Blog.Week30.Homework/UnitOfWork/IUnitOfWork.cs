using System;
using Blog.Week30.Homework.Repository.Abstractions;

namespace Blog.Week30.Homework.UnitOfWork
{
	public interface IUnitOfWork
	{
		public IBlogRepository blogRepository { get; set; }
		public IPostRepository postRepository { get; set; }
        Task Commit(CancellationToken cancellationToken = default);
    }
}

