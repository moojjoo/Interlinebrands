using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InterviewMvcApi.Models
{
    public class InterviewMvcContext : DbContext
    {
        public InterviewMvcContext(DbContextOptions<InterviewMvcContext> options)
            : base(options)
        {
        }

        public DbSet<InterviewMvcApi.Models.MovieItem> MovieItem { get; set; }
        public object Movie { get; internal set; }
    }
}
