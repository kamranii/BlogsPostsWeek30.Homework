using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Week30.Homework.Entities
{
	public class SBlog: BaseEntity<int>
	{
		[Required]
		public string Name { get; set; }
		public int PostsCount { get; set; }

		//nav props
		public virtual ICollection<Post>? Posts { get; set; }
	}
}

