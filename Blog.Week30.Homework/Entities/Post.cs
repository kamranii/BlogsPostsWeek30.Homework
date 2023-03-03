using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Week30.Homework.Entities
{
	public class Post: BaseEntity<int>
	{
		[Required]
		public string Title { get; set; }
		public string? Subtitle { get; set; }
		public string Content { get; set; }
		public DateTime CreationDate { get; set; }
		public int BlogId { get; set; }
		//nav props
		public virtual SBlog Blog { get; set; }
	}
}

