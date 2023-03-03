using System;
using FluentValidation;

namespace Blog.Week30.Homework.Dto
{
	public class Postdto
	{
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual string? Description { get; set; }
        public int BlogId { get; set; }
    }
    public class PostDtoValidatior : AbstractValidator<Postdto>
    {
        public PostDtoValidatior()
        {
            RuleFor(postDto => postDto.Description).MinimumLength(5);
            RuleFor(postDto => postDto.Title).Must(t => t.Contains("Politic") != false);
            RuleFor(p => p.Content).NotEmpty();
        }
    }
}

