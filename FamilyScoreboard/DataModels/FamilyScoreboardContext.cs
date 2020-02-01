
using Microsoft.EntityFrameworkCore;

namespace FamilyScoreboard.DataModels {
    public class FamilyScoreboardContext : DbContext {

        public FamilyScoreboardContext(DbContextOptions<FamilyScoreboardContext> options) : base(options) { }

        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<CompletedTask> CompletedTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<CompletedTask>()
                .HasOne(ct => ct.FamilyMember);
            modelBuilder.Entity<CompletedTask>()
                .HasOne(ct => ct.Task);
        }

    }
}
