using System.Data.Entity;
using SportsRFIDTimer.Domain.Application;
using SportsRFIDTimer.Domain.Race;
using SportsRFIDTimer.Domain.Result;
using SportsRFIDTimer.Domain.User;

namespace SportsRFIDTimer.Repository.Dto
{
    public class SportsRfidTimerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ApplicationState> ApplicationStates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                        .Property(t => t.Name)
                        .IsRequired();
            modelBuilder.Entity<Race>()
                        .Property(t => t.Name)
                        .IsRequired();
            modelBuilder.Entity<Result>()
                        .Property(t => t.RaceId)
                        .IsRequired();
            modelBuilder.Entity<Result>()
                        .Property(t => t.UserId)
                        .IsRequired();
        }
    }
}
