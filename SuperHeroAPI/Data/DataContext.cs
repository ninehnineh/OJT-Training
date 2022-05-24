using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<SuperHero> SuperHeroes { get; set; } = null!;
        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

    }
}
