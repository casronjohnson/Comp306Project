using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Comp306GroupProject.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Comp306GroupProject.Models.JobOffer> JobOffer { get; set; }

        public DbSet<Comp306GroupProject.Models.JobCandidate> JobCandidate { get; set; }
    }
}
