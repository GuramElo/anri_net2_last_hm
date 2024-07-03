using GuramHM.DB.Models;
using Microsoft.EntityFrameworkCore;
namespace GuramHM.DB
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SampleModel> SampleModels { get; set; }
    }
}
