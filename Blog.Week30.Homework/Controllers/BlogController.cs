using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Blog.Week30.Homework.Entities;
using Blog.Week30.Homework.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using Serilog;

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
            _logger.Log( LogLevel.Information,$"Searching all blogs for request: {Request.Path}");
            var blogs = await _unitOfWork.blogRepository.GetAllList();
            if (blogs == null || blogs.Count == 0)
                return NotFound("No blogs were found");
            _logger.LogWarning($"Response generated to the request {Request.Path} is {JsonSerializer.Serialize(blogs)}");
            return blogs;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SBlog>> Get(int id)
        {
            _logger.LogWarning($"Request accepted to find the blog with id of {id} at {DateTime.Now}");
            var blog = await _unitOfWork.blogRepository.Find(id);
            if (blog == null)
            {
                _logger.LogError($"Attempt made to retrieve a non-existing blog at {DateTime.Now}");
                return NotFound("No blog was found");
            }
            _logger.LogWarning($"Retrieved blog: {JsonSerializer.Serialize(blog)}");
            return blog;
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
            try { }
            catch { }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            //log
            _logger.LogCritical($"An attempt is made to delete a blog with id of" +
                $"{id} at {DateTime.Now} by {User}");
            //find
            var blog = await _unitOfWork.blogRepository.Find(id);
            //check
            if(blog == null)
            {
                _logger.LogError($"No blog was found with id {id}. Unsuccessful delete operation " +
                    $"at {DateTime.Now}");
                return NotFound("No blog was found! Could not remove the element");
            }
            //remove
            await _unitOfWork.blogRepository.Delete(blog);
            await _unitOfWork.Commit();
            _logger.LogInformation($"Blog {blog.Name} was deleted from Database at {DateTime.Now}");
            return NoContent();
        }
    }
}

