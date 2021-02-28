using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Data
{
    public interface IContextDb
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        bool AutoCommitEnabled { get; set; }
        bool ValidateOnSaveEnabled { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        //DbEntityEntry Entry(object entity);
        EntityEntry Entry(object entity);
    }
}
