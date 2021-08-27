using System.Data.Entity.ModelConfiguration;
using Core.Models;

namespace Persistence.Configurations
{
    /// <summary>
    /// Fluent API configuration for <see cref="User"/>
    /// </summary>
    public sealed class UserConfiguration : EntityTypeConfiguration<User>
    {
        /// <summary>
        /// Creates an instance of <see cref="UserConfiguration"/>
        /// </summary>
        public UserConfiguration()
        {
            HasKey(user => user.Id);
            Property(user => user.FirstName).IsRequired().HasMaxLength(50);
            Property(user => user.LastName).IsRequired().HasMaxLength(50);
            Property(user => user.Email).IsRequired().HasMaxLength(50);
            Property(user => user.Phone).IsRequired().HasMaxLength(50);
            Property(user => user.State).IsRequired().HasMaxLength(50);
            Property(user => user.Street).IsRequired().HasMaxLength(50);
            Property(user => user.Zip).IsRequired().HasMaxLength(50);
        }
    }
}
