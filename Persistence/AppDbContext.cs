using Core.Models;
using System.Data.Entity;
using Persistence.Configurations;

namespace Persistence
{
    /// <summary>
    /// Represents the database context.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base(ConnectionString)
        {
            Users = Set<User>();
        }

        /// <summary>
        /// Default connection string name
        /// </summary>
        public static string ConnectionString => "name=AppContext";

        internal DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
