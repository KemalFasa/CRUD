using Microsoft.EntityFrameworkCore;
// using SQL.Domain.Common;
using SQL.Domain.Common;
using SQL.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace SQL.Infrastructure.Persistence
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
public DbSet<Tran> Trans { get; set; }
        

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    //     {
    //         // configures one-to-many relationship
    //         modelBuilder.Entity<Grades>()
    //                     .HasMany(g => g.Students)
    //                     .WithOne(s => s.Grade)
    //                     .HasForeignKey(s => s.GradeId);
    //     }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "swn";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "swn";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
