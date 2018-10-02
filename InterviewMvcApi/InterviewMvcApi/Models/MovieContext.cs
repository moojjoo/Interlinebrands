using Microsoft.EntityFrameworkCore;

namespace InterviewMvcApi.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<InterviewMvcContext> options)
           : base(options)
        {
        }

        public DbSet<MovieModel> MovieModels { get; set; }
    }
}
