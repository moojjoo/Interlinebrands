using InterviewMvcApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InterviewMvcApi.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly InterviewMvcContext _context;

        public MovieController(InterviewMvcContext context)
        {
            _context = context;

            if (_context.MovieModel.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all MovieItems.
                _context.MovieModel.Add(new MovieModel { Title = "ItemTest1" });
                _context.SaveChanges();
            }

        }

        [HttpGet]
        public ActionResult<List<MovieModel>> GetAll()
        {
            return _context.MovieModel.ToList();
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public ActionResult<MovieModel> GetById(long id)
        {
            var item = _context.MovieModel.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(MovieModel item)
        {
            _context.MovieModel.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetMovie", new { id = item.ID }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, MovieModel item)
        {
            var todo = _context.MovieModel.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            item.ID = item.ID;
            item.Title = item.Title;
            item.ReleaseDate = item.ReleaseDate;
            item.Genre = item.Genre;
            

            _context.MovieModel.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var movie = _context.MovieModel.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.MovieModel.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }
    }
}