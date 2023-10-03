using Microsoft.EntityFrameworkCore;

namespace BlazorExercise.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>  options) : base(options) 
        { }
    }
}
