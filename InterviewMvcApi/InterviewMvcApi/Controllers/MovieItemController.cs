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

        [HttpPost]
        public IActionResult Create(MovieItem item)
        {
            _context.MovieItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetMovie", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, MovieItem item)
        {
            var todo = _context.MovieItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            item.ID = item.ID;
            item.Title = item.Title;
            item.ReleaseDate = item.ReleaseDate;
            item.Genre = item.Genre;
            

            _context.MovieItems.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var movie = _context.MovieItems.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.MovieItems.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}