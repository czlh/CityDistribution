using IDAL;
using Model.Domain;
using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class AbsFinderBaseBLL<T, D>
        where T : BusinessEntity, new()
        where D : IDAL<T>
    {
        private D _dal;

        protected D Dal
        {
            get
            {
                if (_dal == null)
                    _dal = GetDal();
                return _dal;
            }
        }

        protected abstract D GetDal();

        public T FindById(String id)
        {
            return Dal.FindById(id);
        }


        public IQueryable<T> FindList(Expression<Func<T, bool>> where)
        {
            return Dal.FindList(where);
        }

        public IQueryable<T> FindList()
        {
            return Dal.FindList();
        }

        public IQueryable FindPage(QueryModel qm)
        {
            return Dal.FindPage(qm);
        }
    }
}
