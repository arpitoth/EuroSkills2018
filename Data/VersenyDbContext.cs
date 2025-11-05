using Microsoft.EntityFrameworkCore;
using EuroSkillsApi.Models;

namespace EuroSkillsApi.Data
{
    public class VersenyDbContext : DbContext
    {
        public VersenyDbContext(DbContextOptions<VersenyDbContext> options) : base(options) { }
        public DbSet<Orszag> Orszagok { get; set; }
        public DbSet<Szakma> Szakmak { get; set; }
        public DbSet<Versenyzo> Versenyzok { get; set; }
    }
}