using ExerciseSolutionAPI.Repository.Users;
using Microsoft.EntityFrameworkCore;

namespace ExerciseSolutionAPI.Repository
{
    public class AppDbContext : DbContext
    {
        #region Constructor
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        #endregion

        #region DbSets
        public DbSet<User> Users { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
            base.OnModelCreating(builder);
        }
    }
}
