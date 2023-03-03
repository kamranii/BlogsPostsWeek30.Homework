using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Week30.Homework.Entities
{
	public class BaseEntity<T>
	{
		[Key]
		public virtual T Id { get; set; }
		[MaxLength(200)]
		public virtual string? Description { get; set; }
	}
}

