using Microsoft.EntityFrameworkCore;

namespace InterviewMvcApi.Models
{
    public class InterviewMvcContext : DbContext
    {
        public InterviewMvcContext(DbContextOptions<InterviewMvcContext> options)
            : base(options)
        {
        }

        public DbSet<MovieModel> MovieModel { get; set; }
        public object Movie { get; internal set; }
    }
}
