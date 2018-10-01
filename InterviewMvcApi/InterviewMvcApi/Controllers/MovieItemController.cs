using InterviewMvcApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InterviewMvcApi.Controllers
{
    [Route("api/movieitem")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly MovieContext _context;

        public TodoController(MovieContext context)
        {
            _context = context;

            if (_context.MovieItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.MovieItems.Add(new MovieItem { Title = "Item1" });
                _context.SaveChanges();
            }

        }

        [HttpGet]
        public ActionResult<List<MovieItem>> GetAll()
        {
            return _context.MovieItems.ToList();
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public ActionResult<MovieItem> GetById(long id)
        {
            var item = _context.MovieItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }    
    }
}