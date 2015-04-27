using BLL;
using IDAL;
using Model.Domain;
using Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Service
{
    public class AbsFindBaseService<B, D, E>
        where B : AbsFinderBaseBLL<E, D>, new()
        where D : IDAL<E>
        where E : BusinessEntity, new()
    {
        protected B BLL = new B();

        public E FindById(String id)
        {
            return BLL.FindById(id);
        }


        public IQueryable<E> FindList(Expression<Func<E, bool>> where)
        {
            return BLL.FindList(where);
        }

        public IQueryable<E> FindList()
        {
            return BLL.FindList();
        }

        public IQueryable FindPage(QueryModel qm)
        {
            return BLL.FindPage(qm);
        }
    }
}
