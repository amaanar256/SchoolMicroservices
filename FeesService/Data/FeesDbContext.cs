using Microsoft.EntityFrameworkCore;
using FeesService.Models;

namespace FeesService.Data
{
    public class FeesDbContext : DbContext
    {
        public FeesDbContext(DbContextOptions<FeesDbContext> options) : base(options) { }

        public DbSet<Fee> Fees { get; set; }
    }
}
