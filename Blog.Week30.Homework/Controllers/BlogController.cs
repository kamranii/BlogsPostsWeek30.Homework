using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Week30.Homework.Entities;
using Blog.Week30.Homework.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Week30.Homework.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BlogController> _logger;

        public BlogController(IUnitOfWork unitOfWork,
            ILogger<BlogController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<SBlog>>> Get()
        {
            _logger.Log( LogLevel.Debug, "Listing all blog items");
            var blogs = await _unitOfWork.blogRepository.GetAllList();
            if (blogs == null || blogs.Count == 0)
                return NotFound("No blogs were found");
            return blogs;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SBlog>> Get(int id)
        {
            var book = await _unitOfWork.blogRepository.Find(id);
            if (book == null)
                return NotFound("No blog was found");
            return book;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

