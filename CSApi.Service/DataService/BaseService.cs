using CSApi.Data.Context;
using CSApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSApi.Service.DataService
{
    public class BaseService<TEntity> : IDisposable where TEntity : BaseEntity
    {
        protected DbSet<TEntity> dbcontext;
        protected SimulatorContext db;
        protected ServiceProvider Services;

        public BaseService()
        {
            db = new SimulatorContext();
            dbcontext = db.Set<TEntity>();
            Services = new ServiceProvider();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return dbcontext.Where(x => x.IsDeleted == false).ToList();
        }

        public virtual List<TEntity> GetAllWithOutPassives()
        {
            return dbcontext.Where(x => x.IsDeleted == false && x.IsActive == true).ToList();
        }

        public virtual List<TEntity> GetListWithQuery(Expression<Func<TEntity, bool>> lambda)
        {
            return dbcontext.Where(x => x.IsDeleted == false).Where(lambda).ToList();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            if (entity != null)
            {
                entity.AddDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;
                entity.IsDeleted = false;
                entity.IsActive = true;
                dbcontext.Add(entity);
                SaveChanges();
                return entity;
            }
            else
                return null;
        }

        public virtual TEntity InsertWithOutSave(TEntity entity)
        {
            if (entity != null)
            {
                entity.AddDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;
                entity.IsDeleted = false;
                entity.IsActive = true;
                dbcontext.Add(entity);
                return entity;
            }
            else
                return null;
        }

        public virtual TEntity InsertInactive(TEntity entity)
        {
            if (entity != null)
            {
                entity.AddDate = DateTime.Now;
                entity.UpdateDate = DateTime.Now;
                entity.IsDeleted = false;
                entity.IsActive = false;
                dbcontext.Add(entity);
                SaveChanges();
                return entity;
            }
            else
                return null;
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (entity != null)
            {
                var _entity = dbcontext.Find(entity.ID);
                _entity.AddDate = entity.AddDate;
                _entity.UpdateDate = DateTime.Now;
                _entity.IsDeleted = entity.IsDeleted;
                db.Entry(_entity).CurrentValues.SetValues(entity);
                SaveChanges();
                return _entity;
            }
            else
                return null;
        }

        public virtual bool Delete(int? id)
        {
            if (id != null)
            {
                var entity = dbcontext.Find(id);
                entity.IsDeleted = true;
                entity.DeleteDate = DateTime.Now;
                SaveChanges();
                return true;
            }
            else
                return false;
        }

        public virtual bool HardDelete(int? id)
        {
            if (id != null)
            {
                var entity = dbcontext.Find(id);
                dbcontext.Remove(entity);
                SaveChanges();
                return true;
            }
            else
                return false;
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> lambda)
        {
            return dbcontext.Where(x => !x.IsDeleted).FirstOrDefault(lambda);
        }

        public virtual TEntity GetbyIdWithQuery(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (id != null)
            {
                var entity = dbcontext.Find(id);
                return entity;
            }
            else
                return null;
        }

        public virtual bool AnyWithQuery(Expression<Func<TEntity, bool>> lambda)
        {
            return dbcontext.Where(x => !x.IsDeleted).Any(lambda);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> lambda)
        {
            return dbcontext.Where(x => x.IsDeleted == false).Count(lambda);
        }

        public void Dispose()
        {
            Services.Dispose();
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
