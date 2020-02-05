using FamilyScoreboard.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyScoreboard.Infrastructure {
    public class ScoreboardContext : DbContext {

        public ScoreboardContext(DbContextOptions options) : base(options) { }

        public DbSet<FamilyMember> FamilyMemebers { get; set; }
        public DbSet<Chore> Chores { get; set; }
        public DbSet<CompletedChore> CompletedChores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<FamilyMember>()
                .HasMany(fm => fm.CompletedChores)
                .WithOne(cc => cc.FamilyMember);

            modelBuilder.Entity<CompletedChore>()
                .HasOne(cc => cc.Chore);
        }
    }
}
