using API.Data.Extension;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class ContextDb : DbContext, IContextDb
    {
        //public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        //{
        //    ChangeTracker.LazyLoadingEnabled = false;
        //}

        public ContextDb()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=REYNA\\SQLREYNA;Database=ApiWebCore;Trusted_Connection=True;MultipleActiveResultSets=true;Application Name=ContextDb;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Model.GetEntityTypes()
                .Where(c => c.ClrType.BaseType == typeof(BaseEntity))
                 .Configure(p => p.SetTableName(p.DisplayName()));

            modelBuilder.SetColumnTypeProperties<string>("varchar");
        }

        bool IContextDb.AutoCommitEnabled { get; set; }

        bool IContextDb.ValidateOnSaveEnabled
        {
            get => ChangeTracker.AutoDetectChangesEnabled;
            set => ChangeTracker.AutoDetectChangesEnabled = value;
        }

        EntityEntry IContextDb.Entry(object entity)
        {
            return Entry(entity);
        }

        int IContextDb.SaveChanges()
        {
            return base.SaveChanges();
        }

        Task<int> IContextDb.SaveChangesAsync()
        {
            return SaveChangesAsync();
        }

        DbSet<TEntity> IContextDb.Set<TEntity>()
        {
            return Set<TEntity>();
        }

        //Migrations
        public virtual DbSet<User> User { get; set; }
    }
}
