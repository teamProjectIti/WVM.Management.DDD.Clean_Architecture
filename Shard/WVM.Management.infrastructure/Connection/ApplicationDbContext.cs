using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using WVM.Managment.Domain;
using WVM.Managment.Domain.Data;

namespace WVM.Management.infrastructure.Connection
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }


        public DbSet<Breed> breeds { get; set; }
        public DbSet<Pet> pets  { get; set; }
        // Override SaveChanges to implement soft delete and handle audit properties
        public override int SaveChanges()
        {
            ApplyAuditProperties();
            var result = base.SaveChanges();
            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditProperties();
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        private void ApplyAuditProperties()
        {
            // Iterate over all entries in the change tracker
            foreach (var entry in ChangeTracker.Entries())
            {
                // Check if the entity is of type BaseClass (base class for entities requiring audit properties)
                if (entry.Entity is BaseClass entity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        // Set CreatedAt and IsDeleted properties when a new entity is added
                        entity.CreatedAt = DateTime.UtcNow;
                        entity.IsDeleted = false; // Ensure new entities are not marked as deleted
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        // Set UpdatedAt property when an entity is modified
                        entity.UpdatedAt = DateTime.UtcNow;
                    }
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Global Query Filter for Soft Delete (IsDeleted)
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseClass).IsAssignableFrom(entityType.ClrType))
                {
                    // Explicitly cast 'e' to the correct entity type (BaseClass or derived types)
                    modelBuilder.Entity(entityType.ClrType)
                        .HasQueryFilter(
                            (LambdaExpression)Expression.Lambda(
                                Expression.Not(
                                    Expression.Property(
                                        Expression.Parameter(entityType.ClrType, "e"), "IsDeleted"
                                    )
                                ),
                                Expression.Parameter(entityType.ClrType, "e")
                            )
                        );
                }
            }

            // Apply conventions globally (e.g., max length for strings)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.HasDefaultSchema("dbo"); // Default schema for the DB
            modelBuilder.UseCollation("Latin1_General_CI_AS"); // Example collation, can be customized

            // Configure specific entity properties, such as string lengths
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                property.SetMaxLength(200); // Setting a default max length for all strings
            }
        }
    }
}
