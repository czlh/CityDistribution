using Model.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using Search;
using IDAL;

namespace DAL
{
    public abstract class AbsBaseDAL<T> : IDAL<T> where T : BusinessEntity, new()
    {
        private CDDbContext context = new CDDbContext();
        public CDDbContext CdDbContext
        {
            get
            {
                return context;
            }
        }

        private DbSet<T> set
        {
            get
            {
                return context.Set<T>();
            }
        }
        public virtual T FindById(String id)
        {
            return set.Find(id);
        }

        public virtual int Delete(String id)
        {
            set.Remove(set.Find(id));
            return context.SaveChanges();
        }

        public virtual int Delete(T entity)
        {
            Attach(entity);
            set.Remove(entity);
            return context.SaveChanges();
        }
        public int Save(T entity)
        {
            set.AddOrUpdate(entity);
            return context.SaveChanges();
        }
        public int Create(T entity)
        {
            set.Add(entity);
            return context.SaveChanges();
        }

        public int Creates(List<T> entities)
        {
            set.AddRange(entities);
            return context.SaveChanges();
        }

        public int Update(T entity)
        {
            Attach(entity);

            return context.SaveChanges();
        }

        protected T Attach(T entity)
        {
            T oldE = set.Local.FirstOrDefault(en => en.Id == entity.Id);
            if (oldE != null)
            {
                return oldE;
            }

            return set.Attach(entity);
        }


        public IQueryable<T> FindList(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return set.Where(predicate);
        }

        public IQueryable<T> FindList()
        {
            return set.AsQueryable();
        }

        public IQueryable FindPage(Search.QueryModel qm)
        {
            return set.Where(qm);
        }
    }
}
