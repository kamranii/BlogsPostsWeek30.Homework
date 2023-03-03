using System;
using Blog.Week30.Homework.Controllers;

namespace Blog.Week30.Homework.Loggers
{
	public class CustomLogger: ICustomLogger
	{
        private readonly ILogger<BlogController> _logger;
        public CustomLogger()
		{
		}
	}
}

