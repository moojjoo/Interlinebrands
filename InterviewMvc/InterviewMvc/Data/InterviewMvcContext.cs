using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InterviewMvc.Models
{
    public class InterviewMvcContext : DbContext
    {
        public InterviewMvcContext (DbContextOptions<InterviewMvcContext> options)
            : base(options)
        {
        }

        public DbSet<InterviewMvc.Models.MovieModel> MovieModel { get; set; }
        public object Movie { get; internal set; }
    }
}
