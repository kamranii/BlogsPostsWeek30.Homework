using System;
using FluentValidation;

namespace Blog.Week30.Homework.Dto
{
	public class BlogDto
	{
        public string Name { get; set; }
        public virtual string? Description { get; set; }
    }
    public class BlogDtoValidatior: AbstractValidator<BlogDto>
    {
        public BlogDtoValidatior()
        {
            RuleFor(blogDto => blogDto.Description).MinimumLength(10);
            RuleFor(b => b.Name).Length(10, 100);
        }
    }
}

