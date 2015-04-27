using Model.Domain;
using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace IDAL
{
    public interface IDAL<T> where T : BusinessEntity, new()
    {
        T FindById(String id);

        int Delete(String id);

        int Delete(T entity);

        int Save(T entity);

        int Create(T entity);

        int Creates(List<T> entities);

        int Update(T entity);

        IQueryable<T> FindList(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindList();

        IQueryable FindPage(QueryModel qm);
    }
}
