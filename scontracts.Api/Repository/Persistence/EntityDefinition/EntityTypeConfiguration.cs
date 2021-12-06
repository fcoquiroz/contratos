using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    /// EntityTypeConfiguration
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        /// <summary>
        /// Map
        /// </summary>
        /// <param name="modelBuilder"></param>
        public abstract void Map(EntityTypeBuilder<TEntity> modelBuilder);
    }
    /// <summary>
    /// ModelBuilderExtensions
    /// </summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// AddConfiguration
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="modelBuilder"></param>
        /// <param name="configuration"></param>
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, EntityTypeConfiguration<TEntity> configuration) where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>()); 
        }
    }
}
