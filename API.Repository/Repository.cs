using API.Data;
using API.Entities;
using API.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace API.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private IContextDb _context;
        private readonly IContextFactory _contextFactory;
        private DbSet<T> _entities;

        public Repository(IContextFactory contextFactory)
        {
            _context = contextFactory.GetInstance();
            _contextFactory = contextFactory;
            ForceKeepExistingContext = false;
        }

        public IContextDb context
        {
            get => _context;
            set => _context = value;
        }

        public bool ForceKeepExistingContext { get; set; }

        public bool ValidateOnSaveEnabled { get; set; }

        bool IRepository<T>.ValidateOnSaveEnabled
        {
            get => _context.ValidateOnSaveEnabled;
            set => _context.ValidateOnSaveEnabled = value;
        }
        public virtual IQueryable<T> Table
        {
            get
            {
                if (!ForceKeepExistingContext)
                    _context = _contextFactory.GetInstance();
                return Entities;
            }
        }

        //public virtual T Create()
        //{
        //    return Entities.Create();
        //}

        public virtual T GetById(object id)
        {
            _context = _contextFactory.GetInstance();
            return Entities.Find(id);
        }

        //public virtual T Attach(T entity)
        //{
        //    return Entities.Attach(entity);
        //}

        public virtual void Insert(T entity)
        {
            try
            {
                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(T entity)
        {
            try
            {
                ChangesStateToModifieldIfApplicable(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void ChangesStateToModifieldIfApplicable(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                entry.State = EntityState.Modified;
            }
        }

        private DbSet<T> Entities
        {
            get
            {
                _entities = _context.Set<T>();
                return _entities as DbSet<T>;
            }
        }
    }
}
