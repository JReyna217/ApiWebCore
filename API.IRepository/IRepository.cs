using API.Data;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Table { get; }

        //T Create();

        T GetById(object id);

        //T Attach(T entity);

        void Insert(T entity);

        void Update(T entity);

        bool ValidateOnSaveEnabled { get; set; }

        IContextDb context { get; set; }

        bool ForceKeepExistingContext { get; set; }
    }
}
